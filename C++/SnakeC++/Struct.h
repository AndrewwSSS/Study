#pragma once
#include"Func.h"
#include"Timer.h"
#include<fstream>
#include<iomanip>
#include <filesystem>
#include <Windows.h>
#include<MMSystem.h>


bool elemTaile(point p1, point p2, int j)
{
	if (j == 0) return false;
	else return (p1.x == p2.x && p1.y == p2.y);
}


template<class T>
int kanibal(const T* a, int n, T key, bool (*metchod)(T, T, int))
{
	if (n == 0) return -1;
	for (size_t i = 0; i < n; i++)
	{
		if (metchod(key, a[i], i))
			return i;

	}
	return -1;
}

bool fruit_in_snake_Tail(point p1, point p2)
{
	return (p1.x == p2.x && p1.y == p2.y);
}

template<class T>
int lineSearch(const T* a, int n, T key, bool(*metchod)(T, T))
{
	for (size_t i = 0; i < n; i++)
		if (metchod(a[i], key)) return i;

	return -1;

}


struct snake
{
	// Размеры поля
	int row = 26;			// y 
	int col = 52;			// x



	point fruit;			// Позиция фруктов по корденате x и y
	point pos;				// Позиция головы змейки по корденате x и y


	bool Game_Status;		// Статус игры. false - игра оконченна, true - игра продолжается

	int dir;				// Направление змейки. 1 - влево, 2 - вниз, 3 - вправо, 4 - вперед


	int score;				// Счет
	int eaten_fruit = 0;	// Количество съеденных фруктов
	float time = 0;				// Время игры (в секундах)

	point* tail = nullptr;	// Массив со всеми элементами тела змейки
	int size_tail = 0;		// Размерность тела змейки

	int speed = 65;			// Скорость передвижения змейки (время задержки, чем меньше, тем быстрее)
	int balance_speed;		// Сбалансированная скорость(так-как в консоли каждая ячейка не квадрат и в рост клетка больше в два раза)

	// Цвета змейки	(Поля,бортов, туловища змейки, фрукта)
	int colorField  = 4;
	int colorBorder = 7;
	int colorSnake  = 1;
	int colorFruit  = 14;


	// Переменные для настройки управления передвижениями змейки
	int direction_UP    = 72;
	int direction_DOWN  = 80;
	int direction_LEFT  = 75;
	int direction_RIGHT = 77;
	int EXIT            = 27;

	int game_mode = 1;  // Игровой режим (0 - "В заперти", 1 - "Безграничные поля")

	// Временный счет (используется в режиме "Безкрайние поля")
	int tmp_score;


	// функция срабатывающая один раз в конце игры (Некий деструктор)
	// Очищает массивы
	void end_of_game()
	{

		delete[]tail;
		tail = nullptr;
		size_tail = 0;
	}

	// Задание первоначальных параметров игры
	void setup()
	{
		Game_Status = true;

		dir = 4;

		fruit = { rand() % (col - 2) + 1, rand() % (row - 2) + 1};

		pos = { col / 2, row / 2 };

		score = 0;
		eaten_fruit = 0;
		time = 0;
		size_tail = 0;
	}

	// начальная прорисовка поля 
	void printField()
	{
		system("cls");


		for (size_t i = 0; i < col; i++)
		{
			SetColor(7, colorBorder);
			gotoxy(i, 0);
			cout << ' ';
			SetColor(7, 0);
		}


		for (size_t i = 1; i < row; i++)
		{
			for (size_t j = 0; j < col; j++)
			{
				if (j == 0 || j == col - 1)
				{
					SetColor(7, colorBorder);
					gotoxy(j, i);
					cout << ' ';
					SetColor(7, 0);
				}
				else
				{
					SetColor(7, colorField);
					gotoxy(j, i);
					cout << ' ';
					SetColor(7, 0);
				}

			}
		}

		for (size_t i = 0; i < col; i++)
		{
			SetColor(7, colorBorder);
			gotoxy(i, row - 1);
			cout << ' ';
			SetColor(7, 0);

		}


		gotoxy(fruit.x, fruit.y);
		SetColor(0, colorFruit);
		cout << ' ';
		SetColor(7, 0);

		gotoxy(col + 5, 0);
		SetColor(Yellow, 0);
		cout << "INFO";
		SetColor(Green, 0);

		gotoxy(col + 2, 2);
		cout << "Счет: " << score;

		gotoxy(col + 2, 4);
		SetColor(11, 0);
		cout << "съеденно фруктов: " << eaten_fruit;

		gotoxy(col + 2, 6);
		SetColor(13, 0);
		cout << "Время: " << time << " cек";

		SetColor(10, 0);
		gotoxy(1, 27);
		cout << "Режим игры: ";
		switch (game_mode)
		{
		case 0: cout << "\"Класический\""; break;
		case 1: cout << "\"Безкрайние поля\""; break;
		}


		SetColor(8, 0);
		gotoxy(35, 27);
		cout << "Скорсть игры: ";
		switch (speed)
		{
		case 300: cout << "медленно";	  break;
		case 200: cout << "быстро";		  break;
		case  65: cout << "очень быстро"; break;
		case  30: cout << "невозможно";	  break;
		}

		SetColor(7, 0);
	}


	void input()
	{
		if (_kbhit())
		{
			int c = _getch();


			if (c == EXIT)
			{
				Game_Status = false;
				return;
			}
			else
			{
				// В противоположное направление змее нельзя двигаться(если есть хвост)!!!
				if (direction_UP == c) if (dir != 2 || (size_tail == 0)) dir = 4;
				if (direction_DOWN == c) if (dir != 4 || (size_tail == 0)) dir = 2;
				if (direction_LEFT == c) if (dir != 3 || (size_tail == 0)) dir = 1;
				if (direction_RIGHT == c) if (dir != 1 || (size_tail == 0)) dir = 3;
			}
		}
	}

	bool logic()
	{
		ConsoleCursorStatus(false);
		switch (dir)
		{
		case 1:
			pos.x--;
			break;
		case 2:
			pos.y++;
			break;
		case 3:
			pos.x++;
			break;
		case 4:
			pos.y--;
			break;
		default:
			break;
		}


		switch (game_mode)
		{
		case 0:
			if ((pos.y >= row - 1 || pos.y <= 0) || (pos.x >= col - 1 || pos.x <= 0))
				return false;
		case 1:
			if ((pos.y >= row - 1 || pos.y <= 0) || (pos.x >= col - 1 || pos.x <= 0))
			{
				if (pos.y == row - 1) { pos.y = 1; }
				if (pos.y == 0)		  { pos.y = row - 2; }
				if (pos.x == 0)		  { pos.x = col - 2; }
				if (pos.x == col - 1) { pos.x = 1; }
			}
			break;
		default:
			break;
		}

		addElem(tail, size_tail, pos, 0);

		if (pos.x == fruit.x && pos.y == fruit.y)
		{
			point new_head = pos;

			switch (dir)
			{
			case 1:
				new_head.x--;
				break;
			case 2:
				new_head.y++;
				break;
			case 3:
				new_head.x++;
				break;
			case 4:
				new_head.y--;
				break;
			default:
				break;
			}

			addElem(tail, size_tail, new_head);
			gotoxy(new_head.x, new_head.y);
			SetColor(Green, colorSnake);
			cout << ' ';


			do {


				fruit = { rand() % (col - 2) + 1, rand() % (row - 2) + 1 };
				if (game_mode == 0) tmp_score = 10;
				else
				{
					if (game_mode == 1)
					{
						do
						{
							colorFruit = rand() % (16) + 1;
						}while (colorFruit == colorField || colorFruit == colorSnake || colorFruit == colorBorder);

						switch (colorFruit)
						{
						case 0:case 1:case 2:case 3:case 4:
							tmp_score = 50;
							break;
						case 5:case 6:case 7:case 8:case 9:
							tmp_score = 100;
							break;
						case 10:case 11:case 12:case 13:case 14:
							tmp_score = 200;
							break;
						case 15:case 16:
							tmp_score = 250;
							break;
						}
					}
				}

			} while (lineSearch(tail, size_tail, fruit, fruit_in_snake_Tail) != -1);

			gotoxy(fruit.x, fruit.y);
			SetColor(7, colorFruit);
			cout << ' ';
			SetColor(7, 0);

			score += tmp_score;
			eaten_fruit++;

			gotoxy(col + 2, 2);
			SetColor(Green, 0);
			cout << "Счет: " << score;

			gotoxy(col + 2, 4);
			SetColor(11, 0);
			cout << "съеденно фруктов: " << eaten_fruit;
		}

		switch (dir)
		{
		case 2: case 4: balance_speed = speed * 2;
		case 3: case 1: balance_speed = speed;
		}

		gotoxy(tail[0].x, tail[0].y);
		SetColor(Green, colorSnake);
		cout << ' ';
		SetColor(0, colorField);
		Sleep(balance_speed);

		if (kanibal(tail, size_tail, tail[0], elemTaile) != -1) return false;

		gotoxy(tail[size_tail - 1].x, tail[size_tail - 1].y);
		cout << ' ';
		SetColor(7, 0);
		delElem(tail, size_tail, size_tail - 1);
		return true;
	}
	void start()
	{
		char game_over[] = "Game Over";

		setup();

		printField();
		while (Game_Status == true)
		{
			Timer t;

			input();
			if (Game_Status == false) break;
			Game_Status = logic();

			time += t.elapsed();
			gotoxy(col + 2, 6);
			SetColor(13, 0);
			cout << fixed << setprecision(2);
			cout << "Время: " << time << " cек";
		}


		for (size_t i = 0; i < 40; i++)
		{
			for (size_t j = 0; j < 80; j++)
			{
				gotoxy(j, i);
				cout << " ";
			}

		}

		system("cls");
		gotoxy(20, 13);

		SetColor(Red, 7);
		for (size_t i = 0; i < 9; i++)
		{
			cout << game_over[i] << " ";
			Sleep(100);
		}
		SetColor(7, 0);

		cout << endl << endl;

		end_of_game();

		system("pause");

	}

	void save_color_conf()
	{
		ofstream save("Color_config.bin", ios::binary);

		save.write((char*)&colorField, sizeof(int));
		save.write((char*)&colorBorder, sizeof(int));
		save.write((char*)&colorSnake, sizeof(int));
		save.write((char*)&colorFruit, sizeof(int));


		save.close();
	}

	void load_color_config()
	{
		ifstream load("Color_config.bin", ios::binary);

		if (load.is_open())
		{
			load.read((char*)&colorField, sizeof(int));
			load.read((char*)&colorBorder, sizeof(int));
			load.read((char*)&colorSnake, sizeof(int));
			load.read((char*)&colorFruit, sizeof(int));
		}
		load.close();
	}


	void select_color()
	{
		load_color_config();
		
		Menu m;
		Menu2D select_memu;
		vector<string> t = {"Изменение цветов", "Текущее настройки"};

		vector<string> ColorsField_t =
		{
			"< Цвет поля: черный >", "< Цвет поля: cиний >", "< Цвет поля: зеленый >", "< Цвет поля: голубой >","< Цвет поля: красный >","< Цвет поля: фиолетовый","< Цвет поля: темно-желтый >",
			"< Цвет поля: серый >","< Цвет поля: темно-серый >","< Цвет поля: океановый >", "< Цвет поля: светло-зеленый >","< Цвет поля: кораловый >","< Цвет поля: Светло-красный >","< Цвет поля: светло-фиолетовый >",
			"< Цвет поля: ярко желтый >","< Цвет поля: белый >"
		};

		vector<string> ColorsBorder_t =
		{
			"< Цвет границы: черный >", "< Цвет границы: cиний >", "< Цвет границы: зеленый >", "< Цвет границы: голубой >","< Цвет границы: красный >","< Цвет границы: фиолетовый","< Цвет границы: темно-желтый >",
			"< Цвет границы: серый >","< Цвет границы: темно-серый >","< Цвет границы: океановый >", "< Цвет границы: светло-зеленый >","< Цвет границы: кораловый >","< Цвет границы: Светло-красный >","< Цвет поля: светло-фиолетовый >",
			"< Цвет границы: ярко желтый >","< Цвет границы: белый >"
		};

		vector<string> ColorsSnake_t =
		{
		"< Цвет змейки: черный >", "< Цвет змейки: cиний >", "< Цвет змейки: зеленый >", "< Цвет змейки: голубой >","< Цвет змейки: красный >","< Цвет змейки: фиолетовый","< Цвет змейки: темно-желтый >",
		"< Цвет змейки: серый >","< Цвет змейки: темно-серый >","< Цвет змейки: океановый >", "< Цвет змейки: светло-зеленый >","< Цвет змейки: кораловый >","< Цвет змейки: Светло-красный >","< Цвет змейки: светло-фиолетовый >",
		"< Цвет змейки: ярко желтый >","< Цвет змейки: белый >"
		};

		vector<string> ColorsFruit_t =
		{
		"< Цвет фруктов: черный >", "< Цвет фруктов: cиний >", "< Цвет фруктов: зеленый >", "< Цвет фруктов: голубой >","< Цвет фруктов: красный >","< Цвет фруктов: фиолетовый","< Цвет фруктов: темно-желтый >",
		"< Цвет фруктов: серый >","< Цвет фруктов: темно-серый >","< Цвет фруктов: океановый >", "< Цвет фруктов: светло-зеленый >","< Цвет фруктов: кораловый >","< Цвет фруктов: Светло-красный >","< Цвет фруктов: светло-фиолетовый >",
		"< Цвет фруктов: ярко желтый >","< Цвет фруктов: белый >"
		};

		vector<vector<string>> res_m = { ColorsField_t , ColorsBorder_t, ColorsSnake_t , ColorsFruit_t };
		
		while (true)
		{
			Clear;
			int* pos;
			int start_pos[] = { colorField, colorBorder, colorSnake, colorFruit };
			gotoxy(24, 10);
			SetColor(Yellow, 0);
			cout << "Настройки цветов";
			SetColor(7, 0);
			int	ind = m.select_vertical(t, 24, 12);


			switch (ind)
			{
			case 0:
				Clear
				pos = select_memu.select_vertical(res_m, 20, 12, start_pos);

				colorField = pos[0];
				colorBorder = pos[1];
				colorSnake = pos[2];
				colorFruit = pos[3];

				save_color_conf();
				SetColor(7, 0);
				break;
			case 1:
				Clear;
				SetColor(Yellow, 0);
				gotoxy(20, 9);
				cout << "Текущее цветовые настройки";
				SetColor(7, 0);


				gotoxy(21, 11);
				cout << "Цвет игрового поля - ";
				SetColor(0, colorField);
				cout << " " << endl;
				SetColor(7, 0);


				gotoxy(21, 13);
				cout << "Цвет границ - ";
				SetColor(0, colorBorder);
				cout << " " << endl;
				SetColor(7, 0);

				gotoxy(21, 15);
				cout << "Цвет змейки - ";
				SetColor(0, colorSnake);
				cout << " " << endl;
				SetColor(7, 0);

				gotoxy(21, 17);
				cout << "Цвет фруктов - ";
				SetColor(0, colorFruit);
				cout << " " << endl;
				SetColor(7, 0);

				gotoxy(18, 20);
				Pause
				break;
			case -1:
				SetColor(7, 0);
				return;
				break;
			default:
				break;
			}
				
		}
	

	}

	void miniASCIt(int num)
	{
		switch (num)
		{
		case 134: cout << "F12";			  break;
		case 133: cout << "F11";			  break;
		case  72: cout << "cтрелочка вверх";  break;
		case  80: cout << "cтрелочка вниз";   break;
		case  75: cout << "cтрелочка влево";  break;
		case  77: cout << "cтрелочка вправо"; break;
		case  27: cout << "ESC";			  break;
		case  32: cout << "Пробел";			  break;
		case  13: cout << "Enter";            break;
		case   8: cout << "backspace";		  break;
		case   9: cout << "Tab";			  break;
		case  96: cout << "Ё";				  break;
		case   0: cout << "F1-F10";			  break;
		case   82: cout << "Insert(INS)";	  break;
		case   71: cout << "Home(HM)";		  break;
		case   83: cout << "DEL";			  break;
		case   79: cout << "END";			  break;
		default: cout << (char)num;			  break;
		}
	}

	void snake_control()
	{
		Menu m;
		vector<string> text_s = {
								"Изменить управление для движения вперед",
								"Изменить управление для движения назад",
								"Изменить управление для движения вправо",
								"Изменить управление для движения влево",
								"Выход из игры",
								"Текущее настройки",
							   };

		while (true)
		{
			load_control_config();
			Clear
				int ind = m.select_vertical(text_s, 16, 12);
			int c, k = 0;


			switch (ind)
			{
			case 0:
				Clear
					gotoxy(14, 12);
				SetColor(Yellow, 0);
				cout << "Назначение клавиши для движения вперед";
				SetColor(7, 0);
				do
				{
					if (k == 1)
					{
						gotoxy(14, 12);
						SetColor(Red, 0);
						cout << "Ввод некоректен, одна из клавиш совпадает!!!";
						SetColor(7, 0);
					}
					gotoxy(14, 14);
					cout << "Нажмите любую клавишу чтобы назначить: ";
					c = _getch();
					if (c == 224) c = _getch();
					SetColor(Yellow, 0);
					miniASCIt(c);
					SetColor(7, 0);
					k++;
				} while (c == direction_RIGHT || c == direction_LEFT || c == direction_DOWN);
				direction_UP = c;
				save_control_config();
				gotoxy(14, 16);
				SetColor(Green, 0);
				cout << "Клавиша успешно назначена";
				SetColor(7, 0);
				gotoxy(14, 18);
				Pause
					break;
			case 1:
				Clear
					gotoxy(14, 12);
				SetColor(Yellow, 0);
				cout << "Назначение клавиши для движения назад";
				SetColor(7, 0);

				do
				{
					if (k == 1)
					{
						gotoxy(14, 12);
						SetColor(Red, 0);
						cout << "Ввод некоректен, одна из клавиш совпадает!!!";
						SetColor(7, 0);
					}
					gotoxy(14, 14);
					cout << "Нажмите любую клавишу чтобы назначить: ";
					c = _getch();
					if (c == 224) c = _getch();
					SetColor(Yellow, 0);
					miniASCIt(c);
					SetColor(7, 0);
					k++;
				} while (c == direction_RIGHT || c == direction_LEFT || c == direction_UP);
				direction_DOWN = c;
				save_control_config();
				gotoxy(14, 16);
				SetColor(Green, 0);
				cout << "Клавиша успешно назначена";
				SetColor(7, 0);
				gotoxy(14, 18);
				Pause
					break;
			case 2:
				Clear
					gotoxy(14, 12);
				SetColor(Yellow, 0);
				cout << "Назначение клавиши для движения вправо";
				SetColor(7, 0);

				do
				{
					if (k == 1)
					{
						gotoxy(14, 12);
						SetColor(Red, 0);
						cout << "Ввод некоректен, одна из клавиш совпадает!!!";
						SetColor(7, 0);
					}
					gotoxy(14, 14);
					cout << "Нажмите любую клавишу чтобы назначить: ";
					c = _getch();
					if (c == 224) c = _getch();
					SetColor(Yellow, 0);
					miniASCIt(c);
					SetColor(7, 0);
					k++;
				} while (c == direction_UP || c == direction_LEFT || c == direction_DOWN);
				direction_RIGHT = c;
				save_control_config();
				gotoxy(14, 16);
				SetColor(Green, 0);
				cout << "Клавиша успешно назначена";
				SetColor(7, 0);
				gotoxy(14, 18);
				Pause
					break;
			case 3:
				Clear
					gotoxy(14, 12);
				SetColor(Yellow, 0);
				cout << "Назначение клавиши для движения влево";
				SetColor(7, 0);
				do
				{
					if (k == 1)
					{
						gotoxy(14, 12);
						SetColor(Red, 0);
						cout << "Ввод некоректен, одна из клавиш совпадает!!!";
						SetColor(7, 0);
					}
					gotoxy(14, 14);
					cout << "Нажмите любую клавишу чтобы назначить: ";
					c = _getch();
					if (c == 224) c = _getch();
					SetColor(Yellow, 0);
					miniASCIt(c);
					SetColor(7, 0);
					k++;
				} while (c == direction_RIGHT || c == direction_UP || c == direction_DOWN);
				direction_LEFT = c;
				save_control_config();
				gotoxy(14, 16);
				SetColor(Green, 0);
				cout << "Клавиша успешно назначена";
				SetColor(7, 0);
				gotoxy(14, 18);
				Pause
					break;
			case 4:
				Clear
					gotoxy(14, 12);
				cout << "Назначение клавиши для выхода из игры";

				do
				{
					if (k == 1)
					{
						gotoxy(14, 12);
						SetColor(Red, 0);
						cout << "Ввод некоректен, одна из клавиш совпадает!!!";
						SetColor(7, 0);
					}
					gotoxy(14, 14);
					cout << "Нажмите любую клавишу чтобы назначить: ";
					c = _getch();
					if (c == 224) c = _getch();
					SetColor(Yellow, 0);
					miniASCIt(c);
					SetColor(7, 0);
					k++;
				} while (c == direction_RIGHT || c == direction_UP || c == direction_DOWN || c == direction_LEFT);
				EXIT = c;
				save_control_config();
				gotoxy(14, 16);
				SetColor(Green, 0);
				cout << "Клавиша успешно назначена";
				SetColor(7, 0);
				gotoxy(14, 18);
				Pause

					break;
			case 5:
				Clear
					gotoxy(15, 10);

				SetColor(Yellow, 0);
				cout << "Просмотр текущих настроек управления";
				SetColor(7, 0);

				gotoxy(21, 12);
				cout << "Вперед - ";
				miniASCIt(direction_UP);

				gotoxy(21, 13);
				cout << "Назад - ";
				miniASCIt(direction_DOWN);
				gotoxy(21, 14);

				cout << "Влево - ";
				miniASCIt(direction_LEFT);
				gotoxy(21, 15);

				cout << "Вправо - ";
				miniASCIt(direction_RIGHT);
				gotoxy(21, 16);

				cout << "Выйти из игры - ";
				miniASCIt(EXIT);
				gotoxy(15, 20);
				Pause
					break;
			case -1:
				SetColor(7, 0);
				return;
				break;
			default:
				break;
			}
		}
	}

	void save_control_config()
	{
		ofstream save("Control_config.bin", ios::binary);

		save.write((char*)&direction_UP, sizeof(int));
		save.write((char*)&direction_DOWN, sizeof(int));
		save.write((char*)&direction_LEFT, sizeof(int));
		save.write((char*)&direction_RIGHT, sizeof(int));
		save.write((char*)&EXIT, sizeof(int));

		save.close();
	}


	void key_assignment()
	{
		Menu m;
		vector<string> t = { "Управление во время игры"};


		while (true)
		{
			Clear
			gotoxy(22, 9);
			SetColor(Yellow, 0);
			cout << "Настройки управления";
			int ind = m.select_vertical(t, 20, 12);
			switch (ind)
			{
			case 0:
				snake_control();
				break;
			case -1:
				SetColor(7, 0);
				return;
				break;
			default:
				break;
			}


		}
	}

	void save_other_config()
	{
		ofstream save("other_config.bin", ios::binary);

		save.write((char*)&speed, sizeof(int));
		save.write((char*)&game_mode, sizeof(int));
		save.close();
	}
	void load_other_confing()
	{
		ifstream load("other_config.bin", ios::binary);

		if (load.is_open())
		{
			load.read((char*)&speed, sizeof(int));
			load.read((char*)&game_mode, sizeof(int));
		}
		load.close();
	}

	void game_modes()
	{
		Menu m;
		vector<string> t = { "Класический", "Бескрайние поля..."};
		vector<string> t1 = { "Установить", "Информация про режим"};

		while (true)
		{
			load_other_confing();
			Clear
			gotoxy(22, 8);
			SetColor(Green, 0);
			cout << "Выбор режима игры";

			gotoxy(14, 10);
			SetColor(Yellow, 0);
			cout << "Текущий режим игрый - ";
			switch (game_mode)
			{	
			case 0:
				cout << "Класический";
				break;
			case 1:
				cout << "Бескрайние поля";
				break;
			default:
				break;
			}
			SetColor(7, 0);
			int ind = m.select_vertical(t, 22, 13);

			switch (ind)
			{
			case 0:
				while (true)
				{
					Clear
					gotoxy(20, 9);
					SetColor(Green, 0);
					cout << "Режим \"Класический\"";

					int ind1 = m.select_vertical(t1, 20, 12);
					switch (ind1)
					{
					case 0:
						Clear
						game_mode = 0;
						save_other_config();

						gotoxy(20, 10);
						SetColor(Green, 0);
						cout << "Режим игры успешно установлен";
						SetColor(7, 0);
						gotoxy(18, 11);
						Pause
						return;
						break;
					case 1:
						Clear

						gotoxy(20, 8);
						SetColor(Green, 0);
						cout << "Режим \"Класический\"";

						SetColor(Yellow, 0);
						gotoxy(12, 12);
						cout << "В данном режиме игры, когда змейка";
						gotoxy(11, 13);
						cout << "соприкосается с границей поля, игра заканчивается";
						gotoxy(11, 15);
						Pause
						break;
					case -1:
						SetColor(7, 0);
						return;
						break;
					default:
						break;
					}

				}
				break;
			case 1:
				Clear
				while (true)
				{

					Clear
					
					gotoxy(20, 9);
					SetColor(Green, 0);
					cout << "Режим \"Бескрайние поля\"";
					int ind1 = m.select_vertical(t1, 22, 13);
					switch (ind1)
					{
					case 0:
						Clear
						game_mode = 1;
						save_other_config();
						gotoxy(18, 11);
						SetColor(Green, 0);
						cout << "Режим игры успешно установлен";
						SetColor(7, 0);
						gotoxy(18, 13);
						Pause
						return;
						break;
					case 1:
						Clear

						gotoxy(20, 11);
						SetColor(Green, 0);
						cout << "\"Бескрайние поля\"";

						SetColor(Yellow, 0);
						gotoxy(13, 13);
						cout << "В данном режиме игры, когда змейка";
						gotoxy(13, 14);
						cout << "соприкосается с границей поля,";
						gotoxy(13, 15);
						cout << "она выходит из противоположного края поля,";
						gotoxy(13, 16);
						cout << "различные фрукты, дают по разному очков";
						gotoxy(13, 18);
						Pause
						break;
					case -1:
						SetColor(7, 0);
						return;
						break;
					}
				}
			case -1:
				SetColor(7, 0);
				return;
				break;
			}

		}

	}
	void set_speed()
	{
		Menu m;
		vector<string> t = {
							"Медленно",
							"Быстро", 
							"Очень быстро",
							"Невозможно",
						   };

		while (true)
		{
			load_other_confing();
			
			Clear

			gotoxy(15, 8);
			SetColor(Yellow, 0);
			cout << "Текущий уровень скорости: ";
			
			switch(speed)
			{
			case 300: cout << "медленно";	  break;
			case 200: cout << "быстро";		  break;
			case  65: cout << "очень быстро"; break;
			case  30: cout << "невозможно";	  break;
			}
			SetColor(7, 0);

			int ind = m.select_vertical(t, 26, 10);

			switch (ind)
			{
			case 0:
				speed = 300;
				Clear
				gotoxy(18, 12);
				SetColor(Green, 0);
				cout << "Настройки успешно сохранены";
				SetColor(7, 0);
				gotoxy(18, 13);
				save_other_config();
				Pause
				break;
			case 1:
				speed = 200;
				Clear
					gotoxy(18, 12);
				SetColor(Green, 0);
				cout << "Настройки успешно сохранены";
				SetColor(7, 0);
				gotoxy(18, 13);
				save_other_config();
				Pause
				break;
			case 2:
				speed = 65;
				Clear
					gotoxy(18, 12);
				SetColor(Green, 0);
				cout << "Настройки успешно сохранены";
				SetColor(7, 0);
				gotoxy(18, 13);
				save_other_config();
				Pause
				break;
			case 3:
				speed = 30;
				Clear
					gotoxy(18, 12);
				SetColor(Green, 0);
				cout << "Настройки успешно сохранены";
				SetColor(7, 0);
				gotoxy(18, 13);
				save_other_config();
				Pause
				break;
			case -1:
				SetColor(7, 0);
				return;
				break;
			default:
				break;
			}

		}


	}
	void settings()
	{
		Menu m;
		vector<string> t = { 
							"Режимы игры",
							"Контроллер",
							"Изменение цветов игры",
							"Скорость игры",
						   };

		while (true)
		{
			Clear

			SetColor(Yellow, 0);
			gotoxy(26, 8);
			cout << "Настройки";
			SetColor(7, 0);
			int d = m.select_vertical(t, 20, 10);

			switch (d)
			{
			case 0:
				game_modes();
				break;
			case 1:
				key_assignment();
				break;
			case 2:
				select_color();
				break;
			case 3:
				set_speed();
				break;
			case -1:
				SetColor(7, 0);
				return;
				break;
			default:
				break;
			}


		}


	}
	void load_control_config()
	{
		ifstream load("Control_config.bin", ios::binary);

		if (load.is_open())
		{
			load.read((char*)&direction_UP, sizeof(int));
			load.read((char*)&direction_DOWN, sizeof(int));
			load.read((char*)&direction_LEFT, sizeof(int));
			load.read((char*)&direction_RIGHT, sizeof(int));
			load.read((char*)&EXIT, sizeof(int));
		}
	}
	void menu()
	{
		Menu m;
		vector<string> text = {
								"Начать игру",
								"Настройки",
								"Выйти из игры"
							  };
		
		while (true)
		{
			
			system("cls");
			gotoxy(0, 4);
			SetColor(Red, 0);
			cout << "              **    **  ********  **        **            **      " << endl
				 << "             **    **  ********  **        **         **     **   " << endl
				 << "            ********  **        **        **         **      **  " << endl
				 << "           ********  ********  **        **         **      **  " << endl
				 << "          **    **  **        **        **         **      **  " << endl
				 << "         **    **  ********  ********  ********    **    **   " << endl
				 << "        **    **  ********  ********  ********       **      " << endl;
			SetColor(7, 0);
			
			int ind = m.select_vertical(text, 27, 13);
			switch (ind)
			{
			case 0:
				system("mode con cols=75 lines=30");
				load_control_config();
				load_color_config();
				load_other_confing();
				
				start();
				break;
			case 1:
				settings();
				break;
			case 2: case -1:
				SetColor(7, 0);
				return;
				break;
			default:
				break;
			}
		}




	}
};
