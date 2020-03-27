Funcionalidade: Exemplo1
	Sendo um cliente
	Posso visualizar uma lista de restaurantes
	Para realizar o pedido de uma refeição


Cenário: Visualizar lista de restaurantes
	Dado que acesso o Enjoeat
	Quando solicito a lista de restaurantes
	Então exibe uma lista com os restaurantes e suas informações disponíveis
	| Restaurante    | Descricao  | Tempo      | Classificação |
	| Bread & Bakery | Padaria    | 25 minutos | 4.9           |
	| Burger House   | Hamburgers | 30 minutos | 3.5           |
	| Coffee Corner  | Cafeteria  | 20 minutos | 4.8           |
	| Green Food     | Saudável   | 40 minutos | 4.1           |
	| Ice Cream      | Sorvetes   | 1 hora     | 0             |
	| Tasty Treats   | Doces      | 20 minutos | 4.4           |
