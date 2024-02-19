# LeagueTracker
## Realizacja zdania
### 1. Wymagania
Realizację zadania rozpocząłem od zdefiniowania wymagań, które powinny być spełnione w aplikacji. Były to głównie wymagania funkcjonalne.
### 2. Projekt bazy danych
Projektowanie bazy danych było najbardziej czasochłonne, chciałem aby baza, którą stworzę była w jak największym stopniu przystosowana do późniejszego rozszerzania funkcjonalności systemu. Zdecydowałem się na wybranie na wybranie bazy SQLite z racji na to, iż projekt jest stosunkowo niewielki, a także dane są w łatwy sposób przekazywane innym twórcom, chociaż baza danych postawiona na Dockerze również byłaby dobrym rozwiązaniem.
### 3. Implementacja
Implementacje rozpocząłem od stworzenia modeli ('Code First') oraz podłączenia bazy danych. Kolejno dodałem przykładowe dane, aby mieć na czym pracować oraz podstawowe funkcjonalności niewymagające autoryzacji. Następnie skonfigurowałem system uwierzytelniania i autoryzacji (Identity Framework) bazujący na 'Cookie' również ze względu na rozmiar oraz złożoność aplikacji. Dzięki temu możliwe było zaimplementowanie funkcjonalności polubień.  Na koniec zostało przeprowadzenie małej refaktoryzacji kodu. Dodatkowo w aplikacji wykorzystałem bibliotekę Boostrap do stworzenia strony graficznej.

## Ulepszenia
Ulepszenia jakie mógłbym zasugerować to poszerzenie funkcjonalności systemu o takie rzeczy jak bardziej dokładne statystyki, wprowadzenie możliwości dyskusji użytkowników na tematy związane z ligami czy poszczególnymi meczami oraz implementacja bardziej dopracowanego interfejsu. 
Ze strony technicznej to np. zastosowanie wzorca 'Unit of Work' aby umieścić repozytoria w jednym miejscu i zmniejszyć ilość odwołań w kontrolerach. Można również wykorzystać technologię Cloudinary do łatwego przechowywania zdjęć i filmów w chmurze.
