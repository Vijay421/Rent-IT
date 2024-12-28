/// <reference types="cypress" />

import localConfig from "../../../../backend/local_config.json";

describe("admins can register, update and delete employees", () => {
    before(() => {
        cy.deleteUser("b-user-cy-test", "Qwerty123!");
    });

    it("should let admins register a back office employee", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as admin");
        cy.get("[data-cy='username']").type(localConfig.accounts.admin.userName);
        cy.get("[data-cy='password']").type(localConfig.accounts.admin.password);
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("POST", "https://localhost:53085/api/Admin/employee").as("UpdateRequest");
        cy.get("a[href='/medewerker-aanmaken']").click();

        cy.log("create back office employee");
        cy.get("[data-cy='username']").type("b-user-cy-test");
        cy.get("[data-cy='email']").type("b-user-cy-test@test.com");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='phone']").type("12345");

        cy.get("[data-cy='submit']").click();

        cy.wait('@UpdateRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });
    });

    it("should let back office employees login, update setting and delete the account", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as back office employee");
        cy.get("[data-cy='username']").type("b-user-cy-test");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("PUT", "https://localhost:53085/api/User/*").as("UpdateRequest");
        cy.get("a[href='/account-instellingen']").click();

        cy.log("back office user update settings");
        cy.get("[data-cy='email']").type("b-user-cy-test-updated@test.com");
        cy.get("[data-cy='phone']").type("67890");
        cy.get("[data-cy='address']").type("Adres 123 Hierzo updated");

        cy.get("[data-cy='submit']").click();

        cy.wait('@UpdateRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("DELETE", "https://localhost:53085/api/User/*").as("DeleteRequest");

        cy.log("back office user delete");
        cy.get("[data-cy='delete']").click();
        cy.get("[data-cy='delete']").click();

        cy.wait('@DeleteRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });


        cy.log("redirect to index page");
        cy.url().should("eq", "http://localhost:5173/");
    });
});
