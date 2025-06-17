console.log("Hello, JS in VS Code!");

const createUser = async () => {
    const requestData = {
        firstName: "John",
        lastName: "Doe",
        birthDate: "1990-01-01",
        username: "johndoe",
        password: "securepassword123"
    };

    try {
        const response = await fetch("http://localhost:5126/Users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(requestData)
        });

        const data = await response.json();
        console.log("User created:", data);
    } catch (error) {
        console.error("Error:", error);
    }
};

createUser();
