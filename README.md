# StudentDiary_WPF
Praca domowa t7l27

1) Przenie� prosz� ustawienia connectionstring z pliku app.config do ustawie� u�ytkownika. Podobnie jak to robili�my wcze�niej w aplikacji Windows Forms, wtedy przechowywali�my informacji o tym, czy okno jest zmaksymalizowane. Z tym, �e w ustawieniach nie b�dziemy przechowywa� ca�ego connectionstring�a, ale b�dziemy przechowywacz 5 r�nych ustawie�. B�d� to kolejno:
-Adres serwera bazy danych (w naszym przypadku by� tam (localhost)).
-Nazwa serwera bazy danych (w naszym przypadku SQLEXPRESS).
-Nazwa bazy danych (dowolna nazwa bazy danych).
-U�ytkownik (login, kt�rego u�ywasz w MS SQL Management Studio).
-Has�o do bazy danych (has�o, kt�rego u�ywasz w MS SQL Management Studio).
Zamiast przekazywa� nazw� (name) connectionstring�a do konstruktora klasy ApplicationDbContext, przeka� samego connectionstring�a, zbudowanego z tych warto�ci.
2) Dodaj na formatce g��wnej nowy przycisk �Ustawienia�. Po klikni�ciu tego przycisku powinna otworzy� si� nowa formatka, na kt�rej b�dzie mo�na wprowadzi� wszystkie ustawienia do po��czenia z baz� danych. To znaczy 5 powy�szych w�a�ciwo�ci. Po klikni�ciu przycisku �Zapisz� na tej formatce nadpisz ustawienia u�ytkownika i zr�b restart aplikacji.
3) Przy uruchomieniu aplikacji sprawd�, czy ustawienia u�ytkownika s� prawid�owe. To znaczy czy mo�na po��czy� si� z baz� danych z takimi ustawieniami. Je�eli nie uda si� po��czy� z baz� danych, to wy�wietl odpowiedni komunikat i zapytaj czy chce zmieni� ustawienia. Je�eli b�dzie chcia� poprawi� zmieni�, to otw�rz formatk� z ustawieniami, je�eli nie to wyjd� z aplikacji.
4) Na koniec dodaj do aplikacji Splash Screen. Tak �eby� m�g� wy�wietli� u�ytkownikowi �adny obraz podczas uruchamiania aplikacji.
5) Przeprowad� testy manualne swojej aplikacji w r�nych scenariuszach.