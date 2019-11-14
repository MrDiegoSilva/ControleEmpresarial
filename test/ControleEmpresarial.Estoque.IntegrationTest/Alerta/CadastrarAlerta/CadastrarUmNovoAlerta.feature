Funcionalidade: Cadastrar uma novo alerta
	O usuário fará o cadastro de um alerta pelo site
	preenchendo os campos necessários
	ao terminar receberá uma notificacao 
	de sucesso ou de falha

@TesteAceitacaoCadastroAlerta

Cenário: Cadastrar alerta com sucesso
	Dado que o usuário está no site, na tela inicial, para cadastrar uma novo alerta
	E clica na tab Alerta
	E clica no link Alertas
	E clica no link Novo Alerta
	E preenche os campos com os valores do alerta
		| Campo				 | Valor         |
		| Descricao			 | Winchester    |
		| CondicaoDeAlerta	 | 1			 |
		| Quantidade		 | 20			 |
		| cond1				 |  			 |
	Quando clicar no botao registrar alerta
	Entao Recebe uma mensagem de cadastro de alerta com sucesso

	Cenário: Cadastrar alerta já existente no banco
	Dado que o usuário está no site, na tela inicial, para cadastrar uma novo alerta
	E clica na tab Alerta
	E clica no link Alertas
	E clica no link Novo Alerta
	E preenche os campos com os valores do alerta
		| Campo				 | Valor         |
		| Descricao			 | Winchester    |
		| Quantidade		 | 20			 |
	Quando clicar no botao registrar alerta
	Entao Recebe uma mensagem de erro pois o alerta já existe no banco

	Cenário: Cadastrar alerta sem descrição
	Dado que o usuário está no site, na tela inicial, para cadastrar uma novo alerta
	E clica na tab Alerta
	E clica no link Alertas
	E clica no link Novo Alerta
	E preenche os campos com os valores do alerta
		| Campo				 | Valor         |
		| Descricao			 |		         |
		| Quantidade		 | 20			 |
	Quando clicar no botao registrar alerta
	Entao Recebe uma mensagem de erro poiso alerta não possui descrição

	Cenário: Cadastrar alerta sem quantidade
	Dado que o usuário está no site, na tela inicial, para cadastrar uma novo alerta
	E clica na tab Alerta
	E clica no link Alertas
	E clica no link Novo Alerta
	E preenche os campos com os valores do alerta
		| Campo				 | Valor         |
		| Descricao			 |	Winchester   |
		| Quantidade		 |   			 |
	Quando clicar no botao registrar alerta
	Entao Recebe uma mensagem de erro poiso alerta não possui quantidade
