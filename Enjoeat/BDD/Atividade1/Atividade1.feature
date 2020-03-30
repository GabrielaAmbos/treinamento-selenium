Funcionalidade: Atividade1
	Sendo um cliente
	Posso ter acesso a uma lista de restaurantes
	Para realizar um pedido

Cenário: Verificar itens do menu
	Dado que escolho comprar do "Coffee Corner"
	Quando eu vejo o menu
	Então eu visualizo os itens
		| Nome                     | Descrição                                                     | Valor    |
		| CAPPUCCINO COM CHANTILLY | Tradicional cappuccino com chantilly                          | R$ 9,90  |
		| SUPER EXPRESSO           | Café expresso duplo.                                          | R$ 12,50 |
		| STARBUCKS COPYCAT        | O mais pedido da casa. O verdadeiro café americano pura água. | R$ 15,60 |

Cenário: Adicionar item ao carrinho
	Dado que escolho comprar do "Bread & Bakery"
	Quando eu adiciono 1 "Pão artesanal italiano"
	Então exibe o valor total de "R$ 12,90"

Cenário: Adicionar itens ao carrinho
	Dado que escolho comprar do "Bread & Bakery"
	Quando eu adiciono 1 "Pão artesanal italiano"
	E eu adiciono 2 "Cup Cake"
	Então exibe o valor total de "R$ 19,90"
	
Cenário: Remover item do carrinho
	Dado que escolho comprar do "Green Food"
	Quando eu adiciono 1 "Suco Detox"
	E eu adiciono 2 "Salada Ceasar"
	Então exibe o valor total de "R$ 19,90"
	Quando removo o "Suco Detox" do carrinho
	Então exibe o valor total de "R$ 21,90"

Cenário: Limpar carrinho
	Dado que escolho comprar do "Tasty Treats"
	Quando eu adiciono 1 "Bolo de Morango"
	E eu adiciono 3 "Cup Cake de Choc. Branco"
	Então exibe o valor total de "R$ 57,00"
	Quando eu limpo o carrinho
	Então vejo no carrinho a m ensagem "Seu carrinho está vazio!"

Cenário: Fechar pedido
	Dado que escolho comprar do "Burger House"
	Quando eu adiciono 2 "Classic Burger"
	E eu adiciono 2 "Batatas fritas"
	E eu adiciono 3 "Refrigerante"
	Então exibe o valor total de "R$ R$ 61,50"
	Quando eu fecho o pedido
	Então eu preencho os dados <Nome>, <E-mail>, <Confirmação do e-mail>
		| Nome            | E-mail                   | Confirmação do e-mail    |
		| Comprador teste | compradorteste@teste.com | compradorteste@teste.com |
	E preencho o endereço de entrega
		| Endereço | Número | Complemento |
		| Rua Tal  | 123    | apto. 45    |
	E opto pelo pagamento com "Cartão de Débito"
	Então exibe o os valores
		| Itens    | Frete | Valor Total |
		| R$ 61,50 | 8,00  | 69,50       |
	Quando eu removo 1 "Classic Burger
	Então exibe o os valores
		| Itens    | Frete | Valor Total |
		| R$ 43,00 | 8,00  | 51,00       |
	Quando eu finalizo o pedido
	Então sou informado que o "Pedido foi Concluído"
	E vejo a mensagem "Seu pedido foi recebido pelo restaurante. Prepare a mesa que a comida está chegando!"
	Quando e avalio a experiência com 4 estrelas
	Então 4 estrelas ficam com a cor "Cinza"