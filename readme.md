# Laboratorium 5: Wprowadzenie do Domain Driven Design (DDD) oraz Command Query Responsibility Segregation (CQRS)

## Cel zadania
Celem tego laboratorium jest praktyczne zapoznanie się z kluczowymi aspektami Domain Driven Design (DDD) oraz podstawami Command Query Responsibility Segregation (CQRS). Przed rozpoczęciem, zapoznaj się z dostępnym kodem. W razie pytań, skontaktuj się przez platformę Teams.

### Wskazówki:
- Oddziel warstwy: domenową, aplikacji oraz infrastruktury. W tym projekcie, dla uproszczenia, modele domeny i infrastruktury są identyczne.
- Staraj się stosować zasady SOLID przy projektowaniu klas.
- Projekt uruchamia się pod adresem `http://localhost:8080`.
- Do połączenia z bazą danych użyj narzędzia Studio3T. Wymagany connection string to: `mongodb://root:example@localhost:27017`.
- Podczas instalacji Visual Studio upewnij się, że masz pakiet ASP.NET and Web Development.
- Utwórz klona tego repozytorium, co ułatwi integrację ewentualnych poprawek.

### Przykłady zapytań:
- **Dodanie zamówienia** (POST /api/v1/customers/{customerId}/orders)
    - `customerId`: 3fa85f64-5717-4562-b3fc-2c963f66afa6
    - Produkt `id` pochodzi z `ProductPriceDataApi`.
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
- **Pobranie zamówienia** (GET /api/v1/customers/{customerId}/orders/{orderId})
    - `orderId`: Wartość zwrócona przez zapytanie POST.

**Uwaga:** Z powodów technicznych (serializacja) wszystkie właściwości modeli domenowych muszą mieć settery i gettery, np. `public Guid Id { get; private set; }`.

## Zadania do realizacji

### Ocena 3: Tworzenie nowych użytkowników
Zaimplementuj funkcjonalność tworzenia nowych użytkowników przy użyciu agregatu `Customer`.
1. Utwórz klasy `CreateCustomerCommand` i `GetCustomerQuery`.
2. Zaimplementuj obsługę tych komend i zapytań.
3. Dodaj odpowiednie endpointy do API.
4. Po stworzeniu klienta wygeneruj zdarzenie `CustomerCreatedEvent`.

**Pamiętaj:** Utwórz nową kolekcję dla użytkowników w bazie danych oraz upewnij się, że do warstwy API nie dostaną się modele domenowe.

### Ocena 3.5: Implementacja reguł biznesowych
Stwórz następujące reguły biznesowe:
1. Nazwa użytkownika nie może być pusta i powinna składać się wyłącznie z liter.
2. Łączny koszt produktów w zamówieniu nie może przekroczyć 15 000.

### Ocena 4: Implementacja obsługi błędów oraz metryk
Aby aplikacja była stabilniejsza i zapewniała odpowiedni monitoring, wprowadź:
1. Obsługę błędów za pomocą dedykowanego middleware, który przechwyci wyjątki i zwróci przyjazne komunikaty.
2. Obsługę metryk do monitorowania stabilności systemu poprzez śledzenie wystąpień błędów.

#### Obsługa błędów:
1. Rozszerz klasę `ErrorHandlingMiddleware`, odpowiedzialną za przechwytywanie wyjątków.
2. Middleware powinien zwracać informację z przyjaznym komunikatem błędu.

#### Obsługa metryk:
1. Stwórz `MetricsService`, który będzie odpowiedzialny za zliczanie błędów.
2. Udostępnij metryki pod adresem `/metrics`.

### Ocena 5: Obsługa koszyka produktów
Zaimplementuj funkcjonalność obsługi koszyka produktów.
1. Stwórz agregat do zarządzania koszykiem produktów.
2. Dodaj komendy (commands) i zapytania (queries) dla zarządzania koszykiem:
    - Umożliw dodawanie produktów do koszyka.
    - Opcjonalnie: możliwość usuwania produktów z koszyka jest opcjonalna i może zostać pominięta.
    - Dodaj możliwość pobierania zawartości koszyka.
3. Dodaj odpowiednie endpointy do API.
4. Zmień implementację `Order`, aby była tworzona za pomocą metody `public static Order Create(CheckoutCart checkoutCart)`.

**Uwaga:** Utwórz nową kolekcję dla koszyka produktów w bazie danych.
