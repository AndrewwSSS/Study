#include <iostream>
#include <vector>
#include <string>

enum ConsoleColor
{
    Black = 0, Blue = 1, Green = 2, Cyan = 3, Red = 4, Magenta = 5, Brown = 6, LightGray = 7, DarkGray = 8,
    LightBlue = 9, LightGreen = 10, LightCyan = 11, LightRed = 12, LightMagenta = 13, Yellow = 14, White = 15

};

#include "Menu.h"



using namespace std;


int main()
{

    SetConsoleCP(65001); SetConsoleOutputCP(65001);
    
    /*Menu m;
    vector<string> t = { "1sxxx", "2ввввввввввв", "3xxxxxxxx" };

    m.select_vertical(t, 1, 4);*/






    Menu2D m;
    vector<string> numbers = { "12345678912348", "882", "388888вввввввввв" };
    vector<string> numbers_text = { "One", "Two", "Three" };

    vector<vector<string>> res = { numbers, numbers_text};
    int test[] = { 0, 0 };
    int *p = m.select_vertical(res, 1, 4, test, White, Red);

   /* cout << m.MaxString(res);*/

    for (size_t i = 0; i < res.size(); i++) {
        cout << p[i] << " ";
    }
}

