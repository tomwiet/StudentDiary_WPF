# StudentDiary_WPF
Praca domowa t7l27

1) Przenieœ proszê ustawienia connectionstring z pliku app.config do ustawieñ u¿ytkownika. Podobnie jak to robiliœmy wczeœniej w aplikacji Windows Forms, wtedy przechowywaliœmy informacji o tym, czy okno jest zmaksymalizowane. Z tym, ¿e w ustawieniach nie bêdziemy przechowywaæ ca³ego connectionstring’a, ale bêdziemy przechowywacz 5 ró¿nych ustawieñ. Bêd¹ to kolejno:
-Adres serwera bazy danych (w naszym przypadku by³ tam (localhost)).
-Nazwa serwera bazy danych (w naszym przypadku SQLEXPRESS).
-Nazwa bazy danych (dowolna nazwa bazy danych).
-U¿ytkownik (login, którego u¿ywasz w MS SQL Management Studio).
-Has³o do bazy danych (has³o, którego u¿ywasz w MS SQL Management Studio).
Zamiast przekazywaæ nazwê (name) connectionstring’a do konstruktora klasy ApplicationDbContext, przeka¿ samego connectionstring’a, zbudowanego z tych wartoœci.
2) Dodaj na formatce g³ównej nowy przycisk „Ustawienia”. Po klikniêciu tego przycisku powinna otworzyæ siê nowa formatka, na której bêdzie mo¿na wprowadziæ wszystkie ustawienia do po³¹czenia z baz¹ danych. To znaczy 5 powy¿szych w³aœciwoœci. Po klikniêciu przycisku „Zapisz” na tej formatce nadpisz ustawienia u¿ytkownika i zrób restart aplikacji.
3) Przy uruchomieniu aplikacji sprawdŸ, czy ustawienia u¿ytkownika s¹ prawid³owe. To znaczy czy mo¿na po³¹czyæ siê z baz¹ danych z takimi ustawieniami. Je¿eli nie uda siê po³¹czyæ z baz¹ danych, to wyœwietl odpowiedni komunikat i zapytaj czy chce zmieniæ ustawienia. Je¿eli bêdzie chcia³ poprawiæ zmieniæ, to otwórz formatkê z ustawieniami, je¿eli nie to wyjdŸ z aplikacji.
4) Na koniec dodaj do aplikacji Splash Screen. Tak ¿ebyœ móg³ wyœwietliæ u¿ytkownikowi ³adny obraz podczas uruchamiania aplikacji.
5) PrzeprowadŸ testy manualne swojej aplikacji w ró¿nych scenariuszach.