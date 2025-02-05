extends Control

@onready var matrix_a_input = $"HBoxContainer3/VBoxContainer2/matrix A input"
@onready var matrix_b_input = $"HBoxContainer3/VBoxContainer3/matrix B input"
@onready var matrix_x_output = $"HBoxContainer5/VBoxContainer2/matrix X output"
@onready var inverse_matrix_output = $"HBoxContainer5/VBoxContainer3/inverse matrix output"
@onready var rows_input = $"rows input"
@onready var columns_input = $"columns input"
@onready var generate_matrix_button = $"generate matrix button"
@onready var calculations_report_checkbox = $"HBoxContainer/calculations report checkbox"
@onready var on_screen_checkbox = $"HBoxContainer/on screen checkbox"
@onready var in_file_checkbox = $"HBoxContainer/in file checkbox"
@onready var matrix_a_checkbox = $"VBoxContainer/matrix A checkbox"
@onready var matrix_b_checkbox = $"VBoxContainer/matrix B checkbox"
@onready var find_matrix_range_button = $"HBoxContainer2/find matrix range button"
@onready var find_inverse_matrix_button = $"HBoxContainer2/find inverse matrix button"
@onready var matrix_range_output = $"HBoxContainer4/matrix range output"
@onready var calculate_linear_system_button = $"VBoxContainer2/calculate linear system button"
@onready var window = $Window
@onready var window_output_richlabel = $"Window/window output control/window output richlabel"


func _ready():
	#window.visible = false
	generate_matrix_button.pressed.connect(_on_generate_matrix_button_pressed)
	find_matrix_range_button.pressed.connect(_on_find_matrix_range_pressed)
	find_inverse_matrix_button.pressed.connect(_on_find_inverse_matrix_button_pressed)
	calculate_linear_system_button.pressed.connect(_on_calculate_linear_system_button_pressed)


func _process(_delta):
	if matrix_a_checkbox.button_pressed or matrix_b_checkbox.button_pressed:
		generate_matrix_button.disabled = false
	else:
		generate_matrix_button.disabled = true
	
	if matrix_a_input.text == "" and matrix_b_input.text == "":
		find_inverse_matrix_button.disabled = true
		find_matrix_range_button.disabled = true
	else: 
		find_inverse_matrix_button.disabled = false
		find_matrix_range_button.disabled = false


func _on_find_matrix_range_pressed():
	var matrix = parse_matrix(matrix_a_input.text)
	var rank = calculate_matrix_rank(matrix)
	matrix_range_output.text = str(rank)


func _on_generate_matrix_button_pressed():
	var rows = int(rows_input.text.strip_edges())
	var cols = int(columns_input.text.strip_edges())
	
	var matrix_a = generate_matrix(rows, cols) if matrix_a_checkbox.button_pressed else []
	var matrix_b = generate_matrix(rows, cols) if matrix_b_checkbox.button_pressed else []
	
	if matrix_a_checkbox.button_pressed:
		matrix_a_input.text = format_matrix(matrix_a)
	if matrix_b_checkbox.button_pressed:
		matrix_b_input.text = format_matrix(matrix_b)


func generate_matrix(rows: int, cols: int) -> Array:
	var matrix = []
	for i in range(rows):
		var row = []
		for j in range(cols):
			row.append(randi_range(-9, 9))
		matrix.append(row)
	print(matrix)
	return matrix


func format_matrix(matrix: Array) -> String:
	var result = ""
	for row in matrix:
		result += " ".join(row.map(func(x): return str(x))) + "\n"
	return result.strip_edges(true, true)


func parse_matrix(text: String) -> Array:
	var matrix = []
	for line in text.split("\n"):
		var row = []
		for value in line.split(" "):
			if not value.is_empty():
				row.append(float(value))
		if not row.is_empty():
			matrix.append(row)
	return matrix


func calculate_matrix_rank(matrix: Array) -> int:
	var m = matrix.duplicate(true)
	var rows = m.size()
	var cols = m[0].size()
	var rank = 0
	
	for r in range(rows):
		if r >= cols:
			break
		var pivot_row = r
		while pivot_row < rows and m[pivot_row][r] == 0:
			pivot_row += 1
		if pivot_row == rows:
			continue
		var temp = m[r]
		m[r] = m[pivot_row]
		m[pivot_row] = temp

		for i in range(r + 1, rows):
			if m[i][r] != 0:
				var factor = m[i][r] / m[r][r]
				for j in range(r, cols):
					m[i][j] -= factor * m[r][j]
		rank += 1
	
	return rank


func _on_find_inverse_matrix_button_pressed():
	var matrix = parse_matrix(matrix_a_input.text)
	if matrix.size() != matrix[0].size():
		inverse_matrix_output.text = "Matrix must be square to have an inverse."
		return

	var inverse = calculate_inverse_matrix(matrix)

	if typeof(inverse) == TYPE_STRING:
		inverse_matrix_output.text = inverse
	else:
		inverse_matrix_output.text = format_matrix_with_rounding(inverse)


func format_matrix_with_rounding(matrix: Array) -> String:
	var result = ""
	for row in matrix:
		var formatted_row = []
		for value in row:
			formatted_row.append(str(roundf(value * 100) / 100.0))
		result += " ".join(formatted_row) + "\n"
	return result.strip_edges(true, true)


func calculate_inverse_matrix(matrix: Array) -> Array:
	var n = matrix.size()
	if n == 0:
		return []

	var det = determinant(matrix)
	if det == 0:
		return []

	if n == 1:
		return [[1.0 / det]]

	var cofactor_matrix = []
	for i in range(n):
		cofactor_matrix.append([])
		for j in range(n):
			var submatrix = get_submatrix(matrix, i, j)
			var cofactor = pow(-1, i + j) * determinant(submatrix)
			cofactor_matrix[i].append(cofactor)

	var adjugate_matrix = transpose(cofactor_matrix)

	var inverse_matrix = []
	for i in range(n):
		inverse_matrix.append([])
		for j in range(n):
			inverse_matrix[i].append(adjugate_matrix[i][j] / det)

	return inverse_matrix


func determinant(matrix: Array) -> float:
	var n = matrix.size()
	if n == 0:
		return 0.0
	if n == 1:
		return float(matrix[0][0])
	if n == 2:
		return float(matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0])

	var det = 0.0
	for j in range(n):
		det += pow(-1, j) * matrix[0][j] * determinant(get_submatrix(matrix, 0, j))
	return det


func get_submatrix(matrix: Array, row_to_exclude: int, col_to_exclude: int) -> Array:
	var n = matrix.size()
	var submatrix = []
	for i in range(n):
		if i != row_to_exclude:
			var new_row = []
			for j in range(n):
				if j != col_to_exclude:
					new_row.append(matrix[i][j])
			submatrix.append(new_row)
	return submatrix


func transpose(matrix: Array) -> Array:
	var rows = matrix.size()
	var cols = matrix[0].size()
	var transposed = []
	for j in range(cols):
		transposed.append([])
		for i in range(rows):
			transposed[j].append(matrix[i][j])
	return transposed


func _on_calculate_linear_system_button_pressed():
	var matrix_a = parse_matrix(matrix_a_input.text)
	var matrix_b = parse_matrix(matrix_b_input.text)

	if matrix_a.size() != matrix_a[0].size() or matrix_a.size() != matrix_b.size():
		window_output_richlabel.text=("\n[color=red]Помилка: Розмірність матриць не підходить для розв'язання СЛАР.[/color]")
		return

	window_output_richlabel.text = ("\n[color=blue]Згенеровано протокол обчислення:[/color]")
	window_output_richlabel.text=("\n[color=blue]Знаходження розв’язків СЛАР 1-м методом (за допомогою оберненої матриці):[/color]")

	var inverse_a = calculate_inverse_matrix(matrix_a)

	if typeof(inverse_a) == TYPE_STRING:
		window_output_richlabel.text=("\n[color=red]Помилка обчислення оберненої матриці: " + inverse_a + "[/color]")
		return


	window_output_richlabel.text=("\n[color=green]Знаходження оберненої матриці:[/color]")
	window_output_richlabel.text=("\n[color=green]Вхідна матриця:[/color]\n" + format_matrix(matrix_a))

	var x = multiply_matrix(inverse_a, matrix_b)

	if typeof(x) == TYPE_STRING:
		window_output_richlabel.text=("\n[color=red]Помилка множення матриць: " + x + "[/color]")
		return

	window_output_richlabel.text=("\n[color=green]Розв'язки СЛАР:[/color]\n" + format_matrix(x))
	inverse_matrix_output.text = format_matrix_with_rounding(inverse_a)
	matrix_x_output.text = format_matrix_with_rounding(x)

func multiply_matrix(matrix_a: Array, matrix_b: Array) -> Array:
	var rows_a = matrix_a.size()
	var cols_a = matrix_a[0].size()
	var cols_b = matrix_b[0].size()

	if cols_a != matrix_b.size():
		return []

	var result = []
	for i in range(rows_a):
		result.append([])
		for j in range(cols_b):
			var sum = 0.0
			for k in range(cols_a):
				sum += matrix_a[i][k] * matrix_b[k][j]
			result[i].append(sum)

	return result


func _on_github_pressed():
	OS.shell_open("https://github.com/husarenko/ASPPR_Lab_1")


func _on_window_close_requested():
	window.visible = false
