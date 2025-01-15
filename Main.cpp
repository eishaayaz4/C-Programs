#include <iostream> //for input,otput
#include <fstream>// for file handling
#include <vector>// for dynamic
#include <string>// for using string
#include <cstdlib>// functions like rand()

using namespace std;

struct Student {
    string firstName;
    string lastName;
    string className;
    string regNumber;
    float avgPercentage;
    int marks[5];  // marks for the five subjects
};

// Function to display menu
void displayMenu() {
    cout << "\n----- Student Management System -----" << endl;
    cout << "1. View information of a student" << endl;
    cout << "2. View results corresponding to a registration number" << endl;
    cout << "3. Update information of a student" << endl;
    cout << "4. Add/remove marks for a student" << endl;
    cout << "5. Exit" << endl;
    cout << "Enter your choice: ";
}

// Function to save student data to a file
void saveStudentData(const vector<Student>& students) {
    ofstream outFile("students.txt");

    for (const Student& student : students) {
        outFile << student.firstName << " "
            << student.lastName << " "
            << student.className << " "
            << student.regNumber << " "
            << student.avgPercentage << " ";

        for (int i = 0; i < 5; ++i) {
            outFile << student.marks[i] << " ";
        }
        outFile << endl;  // Move to the next student
    }

    outFile.close();
    cout << "Student data saved to file." << endl;
}

// Function to load student data from a file
vector<Student> loadStudentData() {
    vector<Student> students;
    ifstream inFile("students.txt");

    if (!inFile) {
        cout << "No data file found. Generating random student data..." << endl;
        // If the file doesn't exist, return an empty vector
        return students;
    }

    Student student;
    while (inFile >> student.firstName >> student.lastName >> student.className >> student.regNumber >> student.avgPercentage) {
        for (int i = 0; i < 5; ++i) {
            inFile >> student.marks[i];
        }
        students.push_back(student);
    }

    inFile.close();
    return students;
}

// Function to generate random student data
vector<Student> generateRandomStudents() {
    vector<Student> students;

    // Simulating random student data (using hardcoded data as an example)
    string classes[] = { "RED", "GREEN", "BLUE" };
    string names[] = { "Farrukh", "Ali", "Sarah", "John", "Nina", "Ahmed" };

    for (int i = 0; i < 50; ++i) {
        Student student;
        student.firstName = names[rand() % 6];
        student.lastName = names[rand() % 6];
        student.className = classes[rand() % 3];
        student.regNumber = to_string(1000 + i);  // Unique registration number
        student.avgPercentage = rand() % 100;

        // Random marks for the subjects
        for (int j = 0; j < 5; ++j) {
            student.marks[j] = rand() % 101;  // Random marks between 0-100
        }

        students.push_back(student);
    }

    // Save the generated data for the first time
    saveStudentData(students);

    return students;
}

// Function to display students
void displayStudents(const vector<Student>& students) {
    cout << "\n----- Student List -----" << endl;
    for (const Student& student : students) {
        cout << "Reg. No.: " << student.regNumber
            << ", Name: " << student.firstName << " " << student.lastName
            << ", Class: " << student.className
            << ", Average Percentage: " << student.avgPercentage << "%" << endl;
    }
}

// Function to view results of a student
void viewStudentResults(const vector<Student>& students) {
    string regNo;
    cout << "Enter Registration Number: ";
    cin >> regNo;

    bool found = false;
    for (const Student& student : students) {
        if (student.regNumber == regNo) {
            found = true;
            cout << "\nResults for " << student.firstName << " " << student.lastName << " (Reg. No: " << regNo << "):" << endl;
            cout << "Communication Skills: " << student.marks[0] << endl;
            cout << "Data Structures: " << student.marks[1] << endl;
            cout << "Computer Networks: " << student.marks[2] << endl;
            cout << "Economics: " << student.marks[3] << endl;
            cout << "Operating Systems: " << student.marks[4] << endl;
            break;
        }
    }

    if (!found) {
        cout << "Student with Registration Number " << regNo << " not found!" << endl;
    }
}

// Function to update information of a student
void updateStudentInformation(vector<Student>& students) {
    string regNo;
    cout << "Enter Registration Number: ";
    cin >> regNo;

    bool found = false;
    for (Student& student : students) {
        if (student.regNumber == regNo) {
            found = true;
            cout << "Enter new details for " << student.firstName << " " << student.lastName << ":" << endl;
            cout << "First Name: ";
            cin >> student.firstName;
            cout << "Last Name: ";
            cin >> student.lastName;
            cout << "Class: ";
            cin >> student.className;
            break;
        }
    }

    if (!found) {
        cout << "Student with Registration Number " << regNo << " not found!" << endl;
    }
}

// Function to modify marks for a student
void modifyMarks(vector<Student>& students) {
    string regNo;
    cout << "Enter Registration Number: ";
    cin >> regNo;

    bool found = false;
    for (Student& student : students) {
        if (student.regNumber == regNo) {
            found = true;
            cout << "Modify marks for " << student.firstName << " " << student.lastName << ":" << endl;

            for (int i = 0; i < 5; ++i) {
                cout << "Enter marks for subject " << i + 1 << " (current: " << student.marks[i] << "): ";
                cin >> student.marks[i];
            }

            // Recalculate average percentage
            int totalMarks = 0;
            for (int i = 0; i < 5; ++i) {
                totalMarks += student.marks[i];
            }
            student.avgPercentage = totalMarks / 5.0f;

            break;
        }
    }

    if (!found) {
        cout << "Student with Registration Number " << regNo << " not found!" << endl;
    }
}

int main() {
   

    // Load student data from file (if exists), otherwise generate random data
    vector<Student> students = loadStudentData();
    if (students.empty()) {
        students = generateRandomStudents();  // Generate random data if file doesn't exist
    }

    int choice;
    bool exit = false;

    // Main program loop
    while (!exit) {
        displayMenu();
        cin >> choice;

        switch (choice) {
        case 1:
            displayStudents(students);
            break;
        case 2:
            viewStudentResults(students);
            break;
        case 3:
            updateStudentInformation(students);
            break;
        case 4:
            modifyMarks(students);
            break;
        case 5:
            exit = true;
            cout << "Exiting program..." << endl;
            break;
        default:
            cout << "Invalid choice. Please try again." << endl;
        }
    }

    // Save the updated data when the program exits
    saveStudentData(students);

    return 0;
}
