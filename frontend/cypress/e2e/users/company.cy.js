/// <reference types="cypress" />

const COMPANY = {
    username: "cy-test-company",
    email: "cytestcompany@test-company.com",
    password: "Qwerty123!",
    domain: "test-company.com",
};

const BEHEERDER = {
    username: "cy-test-beheerder",
    password: "Qwerty123!",
};

const HUURDER = {
    username: "cy-test-huurder",
    password: "Qwerty123!",
};

describe("manage subscriptions", () => {
    before(() => {
        cy.deleteUser(COMPANY.username, COMPANY.password);
        cy.deleteUser(BEHEERDER.username, BEHEERDER.password);
        cy.deleteUser(HUURDER.username, HUURDER.password);
    });

    it("should allow companies to register an account", () => {
        cy.intercept("POST", "https://localhost:53085/api/Bedrijf").as("registerCompany");
        cy.visit("http://localhost:5173/registreren/bedrijf");

        cy.log("register company");
        cy.get("[data-cy='username']").type(COMPANY.username);
        cy.get("[data-cy='email']").type(COMPANY.email);
        cy.get("[data-cy='password']").type(COMPANY.password);
        cy.get("[data-cy='bedrijfsnaam']").type("test-company");
        cy.get("[data-cy='adres']").type("Hierzo 1234");
        cy.get("[data-cy='kvk-nummer']").type("123456789012");
        cy.get("[data-cy='phone']").type("06123456789012");
        cy.get("[data-cy='domein']").type(COMPANY.domain);

        cy.get("[data-cy='submit']").click();

        cy.wait("@registerCompany").then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });
    });

    it("should allow companies to register beheerders and huurders", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as company");
        cy.get("[data-cy='username']").type(COMPANY.username);
        cy.get("[data-cy='password']").type(COMPANY.password);

        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.get("a[href='/registreren/huurbeheerder']").click();
        cy.intercept("POST", "https://localhost:53085/api/Bedrijf/zakelijke_beheerder").as("registerBeheerderRequest");

        cy.log("register beheerder");
        cy.get("[data-cy='username']").type(BEHEERDER.username);
        cy.get("[data-cy='email']").type(`cytestbeheerder@${COMPANY.domain}`);
        cy.get("[data-cy='password']").type(BEHEERDER.password);
        cy.get("[data-cy='phone']").type("06123456569312");
        cy.get("[data-cy='company-role']").type("beheerder");

        cy.get("[data-cy='submit']").click();

        cy.wait("@registerBeheerderRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });


        cy.get("a[href='/profiel']").click();
        cy.get("a[href='/registreren/huurder']").click();
        cy.intercept("POST", "https://localhost:53085/api/Bedrijf/zakelijke_huurder").as("registerHuurderRequest");

        cy.log("register huurder");
        cy.get("[data-cy='username']").type(HUURDER.username);
        cy.get("[data-cy='email']").type(`cytesthuurder@${COMPANY.domain}`);
        cy.get("[data-cy='password']").type(HUURDER.password);
        cy.get("[data-cy='phone']").type("06153432569312");
        cy.get("[data-cy='address']").type("12345 Hierzo Straat");
        cy.get("[data-cy='invoice-address']").type("12345 Daarzo Straat");
        cy.get("[data-cy='select-huurbeheerder']").select(BEHEERDER.username);

        cy.get("[data-cy='submit']").click();

        cy.wait("@registerHuurderRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });

        cy.deleteUser(COMPANY.username, COMPANY.password);
        cy.deleteUser(BEHEERDER.username, BEHEERDER.password);
        cy.deleteUser(HUURDER.username, HUURDER.password);
    });
});
