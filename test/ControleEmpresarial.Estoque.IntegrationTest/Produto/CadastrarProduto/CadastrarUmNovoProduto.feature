Funcionalidade: Cadastrar uma novo produto
	O usuário fará o cadastro de um novo produto pelo site
	preenchendo os campos necessários
	ao terminar receberá uma notificacao 
	de sucesso ou de falha

@TesteAceitacaoCadastroProduto

Cenário: Cadastrar produto com sucesso
	Dado que o usuário está no site, na tela inicial, para cadastrar um novo produto
	E clica na tab Produto
	E clica no link Produtos
	E clica no link Novo Produto
	E preenche os campos com os valores do produto
		| Campo				 | Valor         |
		| Codigo			 | TESTE	     |
		| Cor   			 | bicolor       |
		| Tamanho			 | 12            |
		| Comprimento		 | 0,68          |
		| Curvatura			 | 5             |
		| ValorVenda		 | 500,00        |
		| ValorCompra		 | 365,98        |
		| DataEntrada		 | 15/07/2017    |
		| Marca_Descricao	 | Marca Teste   |
		| Material_Descricao | Material      |
		| Categoria_Descricao| Categoria     |
	Quando clicar no botao registrar produto
	Entao Recebe uma mensagem de cadastro de produto realizado com sucesso

	Cenário: Cadastrar produto já existente no banco
	Dado que o usuário está no site, na tela inicial, para cadastrar um novo produto
	E clica na tab Produto
	E clica no link Produtos
	E clica no link Novo Produto
	E preenche os campos com os valores do produto
		| Campo				 | Valor         |
		| Codigo			 | TESTE         |
		| Cor   			 | bicolor       |
		| Tamanho			 | 12            |
		| Comprimento		 | 0,68          |
		| Curvatura			 | 5             |
		| ValorVenda		 | 500,00        |
		| ValorCompra		 | 365,98        |
		| DataEntrada		 | 15/07/2017    |
		| Marca_Descricao	 | Marca Teste   |
		| Material_Descricao | Material      |
		| Categoria_Descricao| Categoria     |

	Quando clicar no botao registrar produto
	Entao Recebe uma mensagem de erro pois o produto já existe no banco

	Cenário: Cadastrar produto sem código
	Dado que o usuário está no site, na tela inicial, para cadastrar um novo produto
	E clica na tab Produto
	E clica no link Produtos
	E clica no link Novo Produto
	E preenche os campos com os valores do produto
		| Campo				 | Valor         |
		| Codigo			 |               |
		| Cor   			 | bicolor       |
		| Tamanho			 | 12            |
		| Comprimento		 | 0,68          |
		| Curvatura			 | 5             |
		| ValorVenda		 | 500,00        |
		| ValorCompra		 | 365,98        |
		| DataEntrada		 | 15/07/2017    |
		| Marca_Descricao	 | Marca Teste   |
		| Material_Descricao | Material      |
		| Categoria_Descricao| Categoria     |
	Quando clicar no botao registrar produto
	Entao Recebe uma mensagem de erro pois o produto não possui codigo
