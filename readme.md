# Laboratorium 5: Wprowadzenie do Domain Driven Design (DDD) oraz Command Query Responsibility Segregation (CQRS)

## Cel zadania
Celem tego laboratorium jest praktyczne zapoznanie siê z kluczowymi aspektami Domain Driven Design (DDD) oraz podstawami Command Query Responsibility Segregation (CQRS). Przed rozpoczêciem, zapoznaj siê z dostêpnym kodem. W razie pytañ, skontaktuj siê przez platformê Teams.

### Wskazówki:
- Pamiêtaj o odpowiednim oddzieleniu warstwy domenowej, aplikacji oraz infrastruktury (w ramach uproszczenia w tym projekcie modele domeny oraz infrastruktury s¹ takie same).
- Staraj siê trzymaæ zasad SOLID w trakcie projektowania klas.
- Projekt uruchamia siê pod adresem http://localhost:8080
- Do po³¹czenia z baz¹ danych mo¿esz u¿yæ narzêdzi takich jak Studio3T. Wymagany jest nastêpuj¹cy ci¹g po³¹czeniowy: `mongodb://root:example@eshop.mongodb:27017`.
- Podczas instalacji Visual Studio upewnij siê, ¿e zainstalowa³eœ pakiet ASP.NET and web development.
- Zachecam do stworzenia klona tego repozytorum, w przypadku potrzeby dodania poprawek z mojej strony bêdzie Pañstwu ³atwiej siê z nimi integrowaæ. 
- Przyk³adowe zapytania
    - POST /api/v1/customers/{customerId}/orders
        - customerId: 3fa85f64-5717-4562-b3fc-2c963f66afa6
        - products id bazuje na `ProductPriceDataApi`
        ```json
        {
          "products": [
            {
              "id": "514f6265-a9b8-46da-a31d-50f4f4c20911", 
              "quantity": 1
            }
          ]
        }
        ```
    - POST /api/v1/customers/{customerId}/orders
        - customerId: 3fa85f64-5717-4562-b3fc-2c963f66afa6
        - products id bazuje na `ProductPriceDataApi`
        ```json
        {
          "products": [
            {
              "id": "514f6265-a9b8-46da-a31d-50f4f4c20911", 
              "quantity": 1
            },
            {
              "id": "514f6265-a9b8-46da-a31d-50f4f4c20912", 
              "quantity": 2
            }
          ]
        }
        ```
    - GET /api/v1/orders/{orderId}
        - orderd: Wartoœæ zwrócona przez zapytanie POST
        
- Z powodów technicznych (serializacja) wszystkie w³aœciwoœci modeli domnenowych musz¹ mieæ settery i gettery np. `public Guid Id { get; private set; }`

### Ocena 3.5: Tworzenie nowych u¿ytkowników
Twoim zadaniem jest zaimplementowanie funkcjonalnoœci tworzenia nowych u¿ytkowników przy u¿yciu agregatu `Customer`.
1. Utwórz klasy `CreateCustomerCommand` i `GetCustomerQuery`.
2. Zaimplementuj obs³ugê tych komend i zapytañ.
3. Dodaj odpowiednie endpointy do API.
4. Upewnij siê, ¿e po stworzeniu klienta generowane jest zdarzenie `CustomerCreatedEvent`.

Pamiêtaj aby stworzyæ now¹ kolekcjê dla tego u¿ytkoników w bazie danych. 

Zwróæ szczegególn¹ uwagê na aby do warstwy API nie dosta³y siê modele domenowe!

### Ocena 4.0: Implementacja regu³ biznesowych
Stwórz nastêpuj¹ce regu³y biznesowe (np. `OrderMustHaveAtLeastOneProductRule`):
1. Nazwa u¿ytkownika nie mo¿e byæ pusta i powinna sk³adaæ siê tylko z liter.
2. £¹czny koszt produktów w zamówieniu nie mo¿e przekroczyæ 15000.

### Ocena 5.0: Obs³uga koszyka produktów
Twoim zadaniem jest zaimplementowanie obs³ugi koszyka produktów.
1. Stwórz nowy agregat do obs³ugi koszyka z produktami (Tylko dodawanie nowych produktów do koszyka).
2. Dodaj odpowiednie komendy (commands) i zapytania (queries) do zarz¹dzania koszykiem.
3. Dodaj odpowiednie endpointy do API.
4. Przerób implementacjê `Order`, aby by³a twrzona w za pomoc¹ nastêpuj¹cej metody `public static Order Create(CheckoutCart checkoutCart)`

**Uwaga:** Utwórz now¹ kolekcjê dla tej funkcjonalnoœci w bazie danych.