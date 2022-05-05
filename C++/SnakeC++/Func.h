#pragma once
#include <filesystem>
#include <fstream>
#include <string>
#include <Windows.h>
#include<MMSystem.h>





enum ConsoleColor
{
	Black = 0, Blue = 1, Green = 2, Cyan = 3, Red = 4, Magenta = 5, Brown = 6, LightGray = 7, DarkGray = 8,
	LightBlue = 9, LightGreen = 10, LightCyan = 11, LightRed = 12, LightMagenta = 13, Yellow = 14, White = 15
};

void gotoxy(int x, int y);

void SetColor(int text, int background);

template<class T>
void addElem(T*& a, int& n, T elem, int pos = -1)
{
	if (pos > n)
		return;
	if (pos == -1)
		pos = n;
	T* temp = new T[n + 1];
	for (size_t i = 0; i < pos; i++)
	{
		temp[i] = a[i];
	}
	temp[pos] = elem;
	for (size_t i = pos; i < n; i++)
	{
		temp[i + 1] = a[i];
	}
	delete a;
	n++;
	a = temp;
}


template<class T>
void delElem(T*& a, int& n, int pos = -1)
{
	if (pos > n)
		return;
	if (pos == -1)
		pos = n - 1;
	T* temp = new T[n - 1];
	for (size_t i = 0; i < pos; i++)
	{
		temp[i] = a[i];
	}
	for (size_t i = pos + 1; i < n; i++)
	{
		temp[i - 1] = a[i];
	}
	delete a;
	n--;
	a = temp;
}

struct point {

	int x;
	int y;
};

void ConsoleCursorStatus(bool sw);