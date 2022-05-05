#include <iostream>
#include "FileManager.h"

using namespace std;


int main()
{
	FileManager m("D:/");
	m.createDirectory("Test");
}