Funcionalidade: Cadastrar uma nova marca
	O usuário fará o cadastro de uma marca pelo site
	preenchendo os campos necessários
	ao terminar receberá uma notificacao 
	de sucesso ou de falha

@TesteAceitacaoCadastroMarca

Cenário: Cadastrar marca com sucesso
	Dado que o usuário está no site, na tela inicial, para cadastrar uma nova marca
	E clica na tab Marca
	E clica no link Marcas
	E clica no link Nova Marca
	E preenche os campos com os valores
		| Campo				 | Valor         |
		| Descricao			 | Marca Teste   |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de cadastro com sucesso

	Cenário: Cadastrar marca já existente no banco
	Dado que o usuário está no site, na tela inicial, para cadastrar uma nova marca
	E clica na tab Marca
	E clica no link Marcas
	E clica no link Nova Marca
	E preenche os campos com os valores
		| Campo				 | Valor         |
		| Descricao			 | Marca Teste   |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro pois a marca já existe no banco

	Cenário: Cadastrar marca sem descrição
	Dado que o usuário está no site, na tela inicial, para cadastrar uma nova marca
	E clica na tab Marca
	E clica no link Marcas
	E clica no link Nova Marca
	E preenche os campos com os valores
		| Campo				 | Valor         |
		| Descricao			 |		         |
	Quando clicar no botao registrar
	Entao Recebe uma mensagem de erro pois a marca não possui descrição
