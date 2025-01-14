/// <reference types="cypress" />

const USERNAME = "cy-test-user";
const EMAIL = "cytestuser@google.com";
const PASSWORD = "Qwerty123!";

describe("manage subscriptions", () => {
    before(() => {
        cy.deleteUser(USERNAME, PASSWORD);


        cy.intercept("POST", "https://localhost:53085/api/ParticuliereUser").as("registerUserRequest");
        cy.visit("http://localhost:5173/registreren");

        cy.log("register particuliere user");
        cy.get("[data-cy='username']").type(USERNAME);
        cy.get("[data-cy='email']").type("cytestuser@google.com");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='phone']").type("12345679");
        cy.get("[data-cy='address']").type("address");

        cy.get("[data-cy='submit']").click();

        cy.wait("@registerUserRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });
    });

    it("should allow zakelijke beheerders to create subscriptions, add a renter to them, and delete the subscription", () => {
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

        // cy.get("[data-cy='address']").type("cy-test-address");
        // cy.get("[data-cy='company-number']").type("271549821111");
        // cy.get("[data-cy='max-renters']").type("20");
        cy.get("[data-cy='end-date']").type("2026-01-01");
        cy.get("[data-cy='subscription-name']").type("cy-test-subscription-name");
        cy.get("[data-cy='pay-as-you-go']").click();

        cy.get("[data-cy='submit']").click();

        cy.wait('@createSubscriptionRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });

        cy.intercept("GET", "https://localhost:53085/api/Abonnement/company").as("getSubscriptionsRequest");
        cy.intercept("GET", "https://localhost:53085/api/User/huurders").as("getRentersRequest");
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

        cy.get("[data-cy='user-search']").last().type(EMAIL + "{enter}").click();
        cy.get("[data-cy='save']").last().click();

        cy.wait('@updateRentersRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });
    });

    it("should let zakelijke huurders rent a vehicle, if they have a subscription", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as zakelijke huurder");
        cy.get("[data-cy='username']").type(USERNAME);
        cy.get("[data-cy='password']").type(PASSWORD);
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("GET", "https://localhost:53085/api/Voertuig").as("getVehicles");
        cy.log("try to rent a vehicle");

        cy.wait(1600);
        cy.get("a[href='/huur-overzicht']").first().click();

        cy.intercept("POST", "https://localhost:53085/api/Huur").as("submitForm");
        cy.log("submit the form");
        cy.log("filter dates");
        cy.get("#date-picker-start").type("2025-01-03");
        cy.get("#date-picker-end").type("2025-01-05");

        cy.get("[data-cy='rent']").last().click();

        cy.get("[data-cy='name']").type("John Doe");
        cy.get("[data-cy='address']").type("Hierzo");
        cy.get("[data-cy='city']").type("Den Haag");
        cy.get("[data-cy='zipcode']").type("ABCD12");
        cy.get("[data-cy='driverid']").type("123456789");
        cy.get("[data-cy='travel-nature']").type("vakantie");
        cy.get("[data-cy='distance']").type("22");
        cy.get("[data-cy='furthest-point']").type("6");
        cy.get("[data-cy='starting-point']").type("Den Haag");
        cy.get("[data-cy='end-point']").type("Den Haag");

        cy.get("[data-cy='submit']").click();
        cy.get("[data-cy='confirm']").click();

        cy.wait("@submitForm").then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });
    })

    it("should remove the subscription", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as zb-user employee");
        cy.get("[data-cy='username']").type("zb-user");
        cy.get("[data-cy='password']").type("Qwerty123!");

        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });

        cy.intercept("PUT", "https://localhost:53085/api/Abonnement/renters/*").as("updateRentersRequest");
        cy.log("remove renter from subscription");

        cy.get("a[href='/profiel']").click();
        cy.get("a[href='/abonnementen']").click();

        cy.get("[data-cy='remove']").last().click();
        cy.get("[data-cy='save']").last().click();

        cy.wait('@updateRentersRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });


        cy.intercept("DELETE", "https://localhost:53085/api/Abonnement/*").as("deleteSubscriptionRequest");
        cy.log("remove subscription");

        cy.get("[data-cy='delete-subscription']").last().click();

        cy.wait("@deleteSubscriptionRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });
    })

    it("should not let zakelijke huurders, without a subscription, rent a vehicle", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as zakelijke huurder");
        cy.get("[data-cy='username']").type(USERNAME);
        cy.get("[data-cy='password']").type(PASSWORD);
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("GET", "https://localhost:53085/api/Voertuig").as("getVehicles");
        cy.log("try to rent a vehicle");

        cy.wait(1600);
        cy.get("a[href='/huur-overzicht']").first().click();

        cy.intercept("POST", "https://localhost:53085/api/Huur").as("submitForm");
        cy.log("submit the form");
        cy.log("filter dates");
        cy.get("#date-picker-start").type("2025-01-03");
        cy.get("#date-picker-end").type("2025-01-05");

        cy.get("[data-cy='rent']").last().click();

        cy.get("[data-cy='name']").type("John Doe");
        cy.get("[data-cy='address']").type("Hierzo");
        cy.get("[data-cy='city']").type("Den Haag");
        cy.get("[data-cy='zipcode']").type("ABCD12");
        cy.get("[data-cy='driverid']").type("123456789");
        cy.get("[data-cy='travel-nature']").type("vakantie");
        cy.get("[data-cy='distance']").type("22");
        cy.get("[data-cy='furthest-point']").type("6");
        cy.get("[data-cy='starting-point']").type("Den Haag");
        cy.get("[data-cy='end-point']").type("Den Haag");

        cy.get("[data-cy='submit']").click();
        cy.get("[data-cy='confirm']").click();

        cy.wait("@submitForm").then((interception) => {
            expect(interception.response.statusCode).to.equal(401);
        });
    })
});
