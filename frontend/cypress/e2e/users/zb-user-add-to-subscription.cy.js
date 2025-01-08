/// <reference types="cypress" />

describe("can register and update employees", () => {
    before(() => {

    });

    it("should allow zakelijke huurders to create subscriptions and add renter to them", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as zb-user employee");
        cy.get("[data-cy='username']").type("zb-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("POST", "https://localhost:53085/api/Abonnement").as("createSubscriptionRequest");
        cy.log("create subscription");

        cy.get("a[href='/abonnement']").click();

        cy.get("[data-cy='company-name']").type("cy-test-company-name");
        cy.get("[data-cy='address']").type("cy-test-address");
        cy.get("[data-cy='company-number']").type("27154982");
        cy.get("[data-cy='max-renters']").type("20");
        cy.get("[data-cy='end-date']").type("2026-01-01"); // TODO
        cy.get("[data-cy='subscription-name']").type("cy-test-subscription-name");
        cy.get("[data-cy='pay-as-you-go']").click();

        cy.get("[data-cy='submit']").click();

        cy.wait('@createSubscriptionRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });


        cy.intercept("GET", "https://localhost:53085/api/Abonnement/company").as("getSubscriptionsRequest");
        cy.intercept("GET", "https://localhost:53085/api/HuurBeheerder/zakelijke-huurders").as("getRentersRequest");
        cy.intercept("PUT", "https://localhost:53085/api/Abonnement/renters/*").as("updateRentersRequest");
        cy.log("add renter to subscription");

        cy.get("a[href='/profiel']").click();
        cy.get("a[href='/abonnementen']").click();

        cy.wait('@getSubscriptionsRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });

        cy.wait('@getRentersRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });

        cy.get("[data-cy='select-renter']").first().select("z-user2");
        cy.get("[data-cy='save']").first().click();

        cy.wait('@updateRentersRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });


        cy.log("remove renter to subscription");
        cy.get("[data-cy='remove']").first().click();
        cy.get("[data-cy='save']").first().click();

        cy.wait('@updateRentersRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });
    });
});
