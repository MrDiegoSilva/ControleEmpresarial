Funcionalidade: Cadastrar uma novo material
	O usuário fará o cadastro de um novo material pelo site
	preenchendo os campos necessários
	ao terminar receberá uma notificacao 
	de sucesso ou de falha

@TesteAceitacaoCadastroMaterial

Cenário: Cadastrar material com sucesso
	Dado que o usuário está no site, na tela inicial, para cadastrar um novo material
	E preenche os campos com os valores do material
		| Campo				 | Valor         |
		| Descricao			 | Material Teste|
	Quando clicar no botao registrar material
	Entao Recebe uma mensagem de cadastro material com sucesso

	Cenário: Cadastrar material já existente no banco
	Dado que o usuário está no site, na tela inicial, para cadastrar um novo material
	E preenche os campos com os valores do material
		| Campo				 | Valor         |
		| Descricao			 | Material Teste|
	Quando clicar no botao registrar material
	Entao Recebe uma mensagem de erro pois o material já existe no banco

	Cenário: Cadastrar material sem descrição
	Dado que o usuário está no site, na tela inicial, para cadastrar um novo material
	E preenche os campos com os valores do material
		| Campo				 | Valor         |
		| Descricao			 |		         |
	Quando clicar no botao registrar material
	Entao Recebe uma mensagem de erro pois o material não possui descrição
