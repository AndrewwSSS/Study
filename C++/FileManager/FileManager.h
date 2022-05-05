#pragma once
#include <filesystem>
#include <map>

namespace fs = std::filesystem;

class FileManager
{
private:
	fs::path currPath;
public:
	FileManager() {}
	FileManager(fs::path path) : currPath(path){}

	// Структурированный вывод всех директорий и поддиректориев
	void printR(std::string path, std::string prefix = "") {
		try {
			if (!fs::is_directory(path)) return;
			for (auto& dir : fs::directory_iterator(path)) {
				std::cout << prefix << dir << std::endl;
				printR(dir.path().string(), prefix + "\t");
			}
		}
		catch (...)
		{
			std::cout << "ERROR\n";
		}
	}
	
	void printCurrDirectory() {
		printDirectory(currPath);
	}
	void createDirectory(std::string name) {
		createDirByPath(currPath / name);
	}

	void setDirectory(std::string path) {
		currPath = path;
	}

	static void printDirectory(fs::path path) {
		std::cout << path.parent_path().filename().string() << std::endl;
		for (auto& it : fs::directory_iterator(path)) {
			std::cout << "  " << it.path().filename().string() << std::endl;
		}
	}
	static bool createDirByPath(fs::path path) {
		if (!fs::exists(path)) {
			fs::create_directory(path);
			return true;
		}
		else return false;
	}
	
	const fs::path& getCurrDirectory() {
		return currPath;
	}
};