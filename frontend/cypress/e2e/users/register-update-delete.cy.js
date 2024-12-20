/// <reference types="cypress" />

describe("can register, update and delete user", () => {
    before(() => {
        cy.log("cleaning up test user if it exists");
        cy.request({
            method: "POST",
            credentials: 'include', // TODO: change to 'same-origin' when in production.
            url: "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true",
            body: {
                email: "p-user-cy-test",
                password: "Qwerty123!",
            },
            failOnStatusCode: false, // Don't fail even if user does not exist.
        }).then((response) => {
            if (response.status === 200) {
                cy.request({
                    method: "DELETE",
                    credentials: 'include', // TODO: change to 'same-origin' when in production.
                    url: "https://localhost:53085/api/User",
                }).then((deleteResponse) => {
                    cy.log("test user deleted, status:", deleteResponse.status);
                });
            } else {
                cy.log("user does not exist, no cleanup needed");
            }
        });
    });

    it("should register a particuliere user", () => {
        cy.intercept("POST", "https://localhost:53085/api/ParticuliereUser").as("registerRequest");
        cy.visit("http://localhost:5173/registreren");

        cy.log("register");
        cy.get("[data-cy='username']").type("p-user-cy-test");
        cy.get("[data-cy='email']").type("p-user-cy-test@test.com");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='phone']").type("12345");
        cy.get("[data-cy='adres']").type("Adres 123 Hierzo");
        cy.get("[data-cy='submit']").click();

        cy.wait('@registerRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });


        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as particuliere user");
        cy.get("[data-cy='username']").type("p-user-cy-test");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("PUT", "https://localhost:53085/api/User/*").as("UpdateRequest");
        cy.visit("http://localhost:5173/account-instellingen");

        cy.log("particuliere update settings");
        // cy.get("[data-cy='username']").type("p-user-cy-test-updated");
        cy.get("[data-cy='email']").type("p-user-cy-test-updated@test.com");
        // cy.get("[data-cy='currentPassword']").type("Qwerty123!");
        // cy.get("[data-cy='updatedPassword']").type("Qwerty123!updated");
        cy.get("[data-cy='phone']").type("67890");
        cy.get("[data-cy='address']").type("Adres 123 Hierzo updated");

        cy.get("[data-cy='submit']").click();

        cy.wait('@UpdateRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("DELETE", "https://localhost:53085/api/User").as("DeleteRequest");
        cy.visit("http://localhost:5173/account-instellingen");

        cy.log("particuliere user delete");
        cy.get("[data-cy='delete']").click();
        cy.wait(100);
        cy.get("[data-cy='delete']").click();

        cy.wait('@DeleteRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });


        cy.log("redirect to index page");
        cy.wait(1500);
        cy.url().should("eq", "http://localhost:5173/");
    });
});
