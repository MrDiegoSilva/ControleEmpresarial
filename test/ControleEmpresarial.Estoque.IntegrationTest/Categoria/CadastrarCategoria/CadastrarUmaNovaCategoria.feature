Funcionalidade: Cadastrar uma nova categoria
	O usuário fará o cadastro de uma categoria pelo site
	preenchendo os campos necessários
	ao terminar receberá uma notificacao 
	de sucesso ou de falha

@TesteAceitacaoCadastroCategoria

Cenário: Cadastrar categoria com sucesso
	Dado que o usuário está no site, na tela inicial, para cadastrar uma nova categoria
	E clica na tab categoria
	E clica no link Categorias
	E clica no link Nova Categoria
	E preenche oo formulario com os valores
		| Campo				 | Valor         |
		| Descricao			 | Armação Teste |
	Quando clicar no botao registrar categoria
	Entao Recebe uma mensagem de cadastro categoria com sucesso

	Cenário: Cadastrar categoria já existente no banco
	Dado que o usuário está no site, na tela inicial, para cadastrar uma nova categoria
	E clica na tab categoria
	E clica no link Categorias
	E clica no link Nova Categoria
	E preenche oo formulario com os valores
		| Campo				 | Valor         |
		| Descricao			 | Armação Teste |
	Quando clicar no botao registrar categoria
	Entao Recebe uma mensagem de erro pois a categoria já existe no banco

	Cenário: Cadastrar categoria sem descrição
	Dado que o usuário está no site, na tela inicial, para cadastrar uma nova categoria
	E clica na tab categoria
	E clica no link Categorias
	E clica no link Nova Categoria
	E preenche oo formulario com os valores
		| Campo				 | Valor         |
		| Descricao			 |		         |
	Quando clicar no botao registrar categoria
	Entao Recebe uma mensagem de erro pois a categoria não possui descrição
