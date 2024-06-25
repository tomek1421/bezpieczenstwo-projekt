# bezpieczenstwo-projekt

### Instrukcja
1.
    1. odpalic dokcer compose
    2. wyłaczyc jak sie skończy - ctrl + C
    3. i odpalic ponownie (ponieważ za pierwszym razem serwer się nie łaczy z bazą danych)
2. 
    1. wejsc do keycloaka - localhost:8080 login: admin, haslo: admin
    2. stworzyc przynajmniej 2 użytkowników i przypisać im role z api-client odpowiednio admin i user


dla uzytkownika z rola Text 'show people' powinno zwrócic dane osób (pola: id, name i age) i uzytkownik moze wejsc do secured page (admin panel)\
dla uzytkowników z rola user 'show people' powinno zwrócic dane osób bez pola age i uzytkownik nie moze wejscdo admin panel\
dla uzytkownikow bez przypisanej roli 'show people' zwroci komunikat - not authenticated to get people 

backend jest odpalony na localhost:4001:
endpoint GET: localhost:4001/people