# Projekt Bezpieczeństwo

## Instrukcja

### 1. Uruchomienie Docker Compose

1. Uruchom Docker Compose:
    ```bash
    docker-compose up --build
    ```

2. zatrzymaj działanie, użyj `Ctrl + C`

3. Ponownie uruchom aplikację Docker Compose:
    ```bash
    docker-compose up --build
    ```
> UWAGA: Ponowne uruchomienie docker-copmose jest konieczne, ponieważ serwer nie łączy się poprawnie z bazą danych za pierwszym razem.

### 2. Konfiguracja Keycloak

1. Zaloguj się do panelu administracyjnego Keycloak:
   - URL: [http://localhost:8080/auth/admin/](http://localhost:8080/auth/admin/)
   - Login: `admin`
   - Hasło: `admin`

2. Utwórz przynajmniej dwóch użytkowników w realmie `Test`  i przypisz im role z clienta `api-client`:
   - Użytkownik 1:
     - Rola: `admin`
   - Użytkownik 2:
     - Rola: `user`

### 3. Konfiguracja Ról API-Client w Keycloak
  - Uprawnienia:
    - Dla użytkowników z rolą `admin`:
      - 'show people' zwraca dane osób (pola: id, name, age).
      - Umożliwia dostęp do secured page (admin panel).
    - Dla użytkowników z rolą `user`:
      - 'show people' zwraca dane osób (pola: id, name) - bez pola `age`.
      - Nie umożliwia dostępu do admin panel.

- Dla użytkowników bez przypisanej roli:
  - 'show people' zwraca komunikat: "Not authenticated to get people".

> UWAGA: Użytkownicy domyślnie mają przypisaną rolę `user`.

### 4. Backend API

- Backend jest uruchomiony na: [http://localhost:4001](http://localhost:4001)
- ZAbezpieczony Endpoint GET dla danych osób: [http://localhost:4001/people](http://localhost:4001/people)