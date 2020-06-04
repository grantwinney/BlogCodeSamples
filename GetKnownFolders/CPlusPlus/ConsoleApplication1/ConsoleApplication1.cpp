#include <windows.h>
#include <iostream>
#include <shlobj.h>
using namespace std;

#pragma comment(lib, "shell32.lib")

int main() {
    PWSTR path = NULL;
    HRESULT result = SHGetKnownFolderPath(FOLDERID_Documents, 0, NULL, &path);

    if (result != S_OK)
        std::cout << "Error: " << result << "\n";
    else
        wprintf(L"%ls\n", path);

    cin.get();  // pause to view result
    return 0;
}
