#define Clear system("cls");
#define Pause system("pause");

#include<fstream>
#include<iomanip>
#include <filesystem>
#include <Windows.h>
#include<MMSystem.h>
#include<string>

#pragma comment (lib, "winmm.lib")

#include "Func.h"
#include "Menu.h"
#include "Struct.h"





void main()
{
	system("mode con cols=75 lines=30");
	setlocale(0, "");


	snake game;
	SetColor(7, 0);
	
	game.menu();
}


