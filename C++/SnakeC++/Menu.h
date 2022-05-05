#pragma once
#include <windows.h>
#include <vector>
#include <iostream>
#include <string>
#include<conio.h>

using namespace std;



class Menu
{

public:
	// Длина самой длинной строчки в векторе
	int MaxString(vector<string> a)
	{ 
		int max = a[0].length();

		for (int i = 1; i < a.size(); i++)
			if (a[i].length() > max) max = a[i].length();

		return max;
	}

	int select_vertical(vector <string> menu, int posX, int posY, ConsoleColor colorT = Black , ConsoleColor colorB = White)
	{
		char c;
		int pos = 0;
		int lenMaxString = MaxString(menu);
		int lenArr = menu.size();
		do
		{
			for (int i = 0; i < menu.size(); i++)
			{
				if (i == pos)
				{
					SetColor(colorT, colorB);
					gotoxy(posX, posY+i);

					if (lenMaxString - menu[i].size() == 1) cout << " ";
					for (int i = 0; i < lenMaxString; i++) cout << " ";
					if (lenMaxString - menu[i].size() != 1) cout << " ";

					gotoxy(posX + (lenMaxString - menu[i].size() == 1) + (lenMaxString - menu[i].size()) / 2, posY + i);
					cout << menu[i] << endl;

					SetColor(15, 0);
				}
				else
				{
					SetColor(7, 0);
					gotoxy(posX, posY + i);

					if (lenMaxString - menu[i].size() != 1) cout << " ";
					for (int i = 0; i < lenMaxString+1; i++) cout << " ";
					if (lenMaxString - menu[i].size() != 1) cout << " ";

					gotoxy(posX + (lenMaxString - menu[i].size() == 1) + (lenMaxString - menu[i].size()) / 2, posY + i);
					cout << menu[i] << endl;
					SetColor(0, 15);
				}

			}
			c = _getch();
			switch (c)
			{
			case 72: //вверх
				if (pos > 0) pos--;
				else pos = menu.size() - 1;
				break;
			case 80: // вниз
				if (pos < menu.size() - 1) pos++;
				else pos = 0;
				break;
			case 27: // Esc (выход)
				return -1;
				break;
			case 13:
				break;
			default:
				break;
			}
		} while(c != 13);
		SetColor(7, 0);
		return pos;
	}
};

class Menu2D
{
public:
	// Длина самой длинной строчки в векторе
	int MaxString(vector<vector<string>> a)
	{
		int max = a[0][0].length();

		for (int i = 1; i < a.size(); i++)
			for (size_t j = 0; j < a[i].size(); j++)
				if (a[i][j].length() > max) max = a[i][j].length();

		return max;
	}

	int* select_vertical(vector<vector<string>> menu, int posX, int posY, int* start, ConsoleColor colorT = Black, ConsoleColor colorB = White)
	{
		char c;
		int pos = 0;
		
		int lenArr = menu.size();
		int tmp_i;

		int* positions = new int[menu.size()];
		positions = start; // Изначальные позиции элементов

		do
		{
			int lenMaxString = MaxString(menu);
			for (int i = 0; i < menu.size(); i++)
			{
				if (i == pos)
				{
					SetColor(colorT, colorB);
					gotoxy(posX, posY + i);

					for (int i = 0; i < lenMaxString; i++) cout << " ";

					gotoxy(posX, posY + i);
					cout << menu[i][positions[i]] << endl;

					SetColor(15, 0);
				}
				else
				{
					SetColor(15, 0);
					gotoxy(posX, posY + i);

					
					for (int i = 0; i < lenMaxString; i++) cout << " ";

					gotoxy(posX, posY + i);
					cout << menu[i][positions[i]] << endl;
					SetColor(0, 15);
				}

			}
			c = _getch();
			
			switch (c)
			{
			case 72: //вверх
				if (pos > 0) pos--;
				else pos = menu.size() - 1;
				break;
			case 80: // вниз
				if (pos < menu.size() - 1) pos++;
				else pos = 0;
				break;
			case 27: // Esc (выход)
				return positions;
				break;
			case 77: // Вправо
				if (positions[pos] != menu[pos].size() - 1)  positions[pos]++;
				else positions[pos] = 0;
				break;
			case 75: // Влево
				if(positions[pos] != 0)  positions[pos]--;
				else  positions[pos] = menu[pos].size() - 1;
				break;
			case 13:
				break;
			default:
				break;
			}

		} while (c != 13);
		SetColor(7, 0);
		return positions;
	}
};