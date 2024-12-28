/// <reference types="cypress" />

import localConfig from "../../../../backend/local_config.json";

describe("can register, update and delete employees", () => {
    before(() => {
        cy.log("Let the back office employee be locked out, through 5 incorrect login attempts");
        cy.loginFail("b-user", "Wrongpass!");
        cy.loginFail("b-user", "Wrongpass!");
        cy.loginFail("b-user", "Wrongpass!");
        cy.loginFail("b-user", "Wrongpass!");
        cy.loginFail("b-user", "Wrongpass!");
    });

    it("should lock out employees after 5 consecutive incorrect login attempts", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequestFail");
        cy.visit("http://localhost:5173/login");

        cy.log("login as backoffice employee");
        cy.get("[data-cy='username']").type("b-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequestFail").then((interception) => {
            expect(interception.response.statusCode).to.equal(401);
        });
    });

    it("should allow admins to unblock the employee", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as back office employee");
        cy.get("[data-cy='username']").type(localConfig.accounts.admin.userName);
        cy.get("[data-cy='password']").type(localConfig.accounts.admin.password);
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("POST", "https://localhost:53085/api/Admin/unblock-employee/*").as("UnblockRequest");
        cy.get("a[href='/medewerkersoverzicht']").click();
        cy.get("[data-cy='unblock']").click();

        cy.wait('@UnblockRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
    });

    it("should login as the unblocked back office employee", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequestSuccess");
        cy.visit("http://localhost:5173/login");

        cy.log("login as back office employee");
        cy.get("[data-cy='username']").type("b-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequestSuccess").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
    });
});
