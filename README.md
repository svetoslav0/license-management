# Software License Management Module

  

### 📦 Project Description

  

This project is a **Software License Management Module** built as part of a technical assessment. It provides a simple system for managing users and their software licenses based on a subscription plan.

  

The system allows an organization to:

  

- Create and manage users

- Assign or unassign software licenses

- View and switch between subscription plans with different seat limits (Basic, Pro, Enterprise)

  

It enforces key business rules, including:

  

- Users can only have one license at a time

- License assignments cannot exceed the current plan's seat limit

- Licenses cannot be unassigned from users who don’t have one

  

>  **Note:**  While SQLite is used in this implementation to simplify testing for reviewers and avoid setup complexity, in a production environment **MySQL** (or another robust RDBMS) would be used for better scalability and performance.

  

The React-based frontend displays user and plan information, and provides controls to assign/unassign licenses and switch plans.

  

---

  

### 🛠️ Tech Stack

  

-  **Backend:** ASP.NET Core API (.NET 8)

-  **Frontend:** React 19

-  **Styling:** Tailwind CSS

-  **Database:** SQLite

  

> SQLite is used for ease of testing and setup when cloning the repository. This project was developed as part of a job interview assignment, so the goal was to ensure the environment can be spun up quickly without requiring additional infrastructure.

  
### ⚠️ What Could Have Gone Better

  

#### **Server-side**
- ❌ No exception handling implemented — in a real-world project, structured error handling and proper response codes would be essential for API robustness and client clarity.

  

#### **Client-side**
- 🎨 The UI design was not developed at all — it's intentionally rough and lacks polish. Visual design, layout, and usability were not prioritized due to the focus being on functional requirements for the assignment.



---

  

### 🚀 Installation & Setup

  

1.  **Clone the repository**

```bash

git clone <repository-url>

cd <repository-folder>

```

  

2.  **Run the Backend (ASP.NET Core API)**

Navigate to the `server` directory:

```bash

cd server

```

You can either use Visual Studio to start the project of just use `dotnet run` to start it. Make sure you have the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.
  

The backend API should now be running at:

[https://localhost:7012/](https://localhost:7012/)

  

3.  **Run the Frontend (React)**

Open a new terminal window, navigate to the `client` directory:

```bash

cd client

npm install

npm run start

```

  

The frontend should now be running at:

[http://localhost:3009/](http://localhost:3009/)