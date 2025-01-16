describe("Back office employees can assess subscriptions", () => {
    it('should allow back office employees to see all subscriptions and assess each one on a case-by-case basis', () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("Login as zakelijke beheerder");
        cy.get("[data-cy='username']").type("zb-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
        cy.wait(1600);

        cy.get("a[href='/abonnement']").click();
        cy.log("to /abonnement page");

        cy.get("[data-cy='max-renters']").type("12");
        cy.get("[data-cy='start-date']").type("2025-05-12");
        cy.get("[data-cy='end-date']").type("2025-06-25");
        cy.get("[data-cy='subscription-name']").type("testsubscription1");
        cy.get("[data-cy='prepaid']").click();
        cy.get("[data-cy='submit']").click();

        cy.get("[data-cy='max-renters']").clear().type("15");
        cy.get("[data-cy='start-date']").type("2025-02-01");
        cy.get("[data-cy='end-date']").clear().type("2025-10-14");
        cy.get("[data-cy='subscription-name']").clear().type("testsubscription2");
        cy.get("[data-cy='pay-as-you-go']").click();
        cy.get("[data-cy='submit']").click();

        cy.get("[data-cy='max-renters']").clear().type("3");
        cy.get("[data-cy='start-date']").type("2025-02-21");
        cy.get("[data-cy='end-date']").clear().type("2025-04-01");
        cy.get("[data-cy='subscription-name']").clear().type("testsubscription3");
        cy.get("[data-cy='prepaid']").click();
        cy.get("[data-cy='submit']").click();

        cy.get("button").contains("Logout").click();

        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("Login as back office medewerker");
        cy.get("[data-cy='username']").type("b-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
        cy.wait(1600);

        cy.intercept("GET", "https://localhost:53085/api/Abonnement").as("getAbonnementen");

        cy.get("a[href='/abonnementsoverzicht']").click();
        cy.log("to /abonnementsoverzicht page");

        cy.wait("@getAbonnementen");

        cy.log("Check if all abonnementen are present");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().should("have.length", 6);

        cy.log("Check if 2nd abonnement status is Nog niet beoordeeld");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-content-geaccepteerd']").should("have.text","Status: Nog niet beoordeeld");

        cy.log("Check if 4th abonnement status is Nog niet beoordeeld");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(3 + 2).find("[data-cy='abonnement-content-geaccepteerd']").should("have.text","Status: Nog niet beoordeeld");

        cy.log("Click on goedkeuren for the 2nd abonnement and check if the status is now Goedgekeurd");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-keuren-goedkeuren-button']").click();
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-content-geaccepteerd']").should("have.text","Status: Goedgekeurd");

        cy.log("Click on goedkeuren for the 3rd abonnement and check if the status is now Goedgekeurd");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-keuren-goedkeuren-button']").click();
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-content-geaccepteerd']").should("have.text","Status: Goedgekeurd");

        cy.log("Click on afkeuren, type in a reason and click on confirm for the 4th abonnement and check if the status is now Afgekeurd and the reden matches");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(3 + 2).find("[data-cy='abonnement-keuren-afkeuren-button']").click();
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(3 + 2).find("[data-cy='abonnement-keuren-textarea']").type("Test afgekeurd value");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(3 + 2).find("[data-cy='abonnement-keuren-confirm-button']").click();
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(3 + 2).find("[data-cy='abonnement-content-geaccepteerd']").should("have.text","Status: Afgekeurd");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(3 + 2).find("[data-cy='abonnement-content-reden']").should("have.text","Reden: Test afgekeurd value");

        cy.log("Click on afkeuren, type in a reason and click on confirm for the 2nd abonnement and check if the status is now Afgekeurd and the reden matches");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-keuren-afkeuren-button']").click();
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-keuren-textarea']").type("Test afgekeurd value2");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-keuren-confirm-button']").click();
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-content-geaccepteerd']").should("have.text","Status: Afgekeurd");
        cy.get("[data-cy='abonnement-overzicht-content-box']").children().eq(1 + 2).find("[data-cy='abonnement-content-reden']").should("have.text","Reden: Test afgekeurd value2");

        cy.log("Logout");
        cy.get("button").contains("Logout").click();

        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("Login as zakelijke beheerder");
        cy.get("[data-cy='username']").type("zb-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
        cy.wait(1600);

        cy.get("a[href='/abonnementen']").click();
        cy.log("to /abonnementen page");
        cy.wait(1000);

        cy.get("[data-cy='subs-subs']").children().then((children) => {
            const totalSubscriptions = children.length;
            for (let i = 0; i < totalSubscriptions; i++) {
                cy.get("[data-cy='subs-subs']")
                    .children()
                    .first()
                    .find("[data-cy='delete-subscription']")
                    .click();
                cy.wait(100);
            }
        });
    });
});