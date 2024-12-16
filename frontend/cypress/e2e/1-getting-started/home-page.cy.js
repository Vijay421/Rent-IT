/// <reference types="cypress" />

// Welcome to Cypress!
//
// This spec file contains a variety of sample tests
// for a todo list app that are designed to demonstrate
// the power of writing tests in Cypress.
//
// To learn more about how Cypress works and
// what makes it such an awesome testing tool,
// please read our getting started guide:
// https://on.cypress.io/introduction-to-cypress

describe("particuliere user tests", () => {
    beforeEach(() => {
        cy.visit("http://localhost:5173/login");
    });

    it("should login as particuliere user", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.intercept("GET", "https://localhost:53085/api/Voertuig").as("getVehicles");

        cy.get("#login-gebruikersnaam").type("p-user");
        cy.get("#login-password").type("Qwerty123!");

        cy.get(".login-box__button").click();

        cy.wait('@loginRequest').then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });

        cy.wait(1500);
        cy.get('a[href="/huur-overzicht"]').click();
        cy.wait("@getVehicles");

        // Show all vehicles.
        cy.get(".rental-vehicle-box__div").should("have.length", 7);

        // Filter type.
        cy.get(".divTop-divSelect-voertuig-dropdown").select("caravan");
        cy.get(".rental-vehicle-box__div").should("have.length", 2);

        // Reset filters.
        cy.get(".divTop-reset-filters__button").click();
        cy.get(".rental-vehicle-box__div").should("have.length", 7);

        // Filter dates.
        cy.get("#date-picker-start").type("2018-01-01");
        cy.get("#date-picker-end").type("2019-01-01");
        cy.get(".rental-vehicle-box__div").should("have.length", 1);

        // Filter brand.
        cy.get(".divTop-reset-filters__button").click();
        cy.get(".divTop-divSelect-merk-dropdown").select("Toyota");
        cy.get(".rental-vehicle-box__div").should("have.length", 1);

        // Filter price 0-50.
        cy.get(".divTop-reset-filters__button").click();
        cy.get(".divTop-divSelect-prijs-dropdown").select("0-50");
        cy.get(".rental-vehicle-box__div").should("have.length", 3);

        // Filter availability.
        cy.get(".divTop-reset-filters__button").click();
        cy.get(".divTop-divSelect-beschikbaarheid-dropdown").select("Beschikbaar");
        cy.get(".rental-vehicle-box__div").should("have.length", 7);
        cy.get(".divTop-divSelect-beschikbaarheid-dropdown").select("Onbeschikbaar");
        cy.get(".rental-vehicle-box__div").should("have.length", 0);

        // Sort ascending.
        cy.get(".divTop-reset-filters__button").click();
        cy.get(".divTop-divSelect-sorteren-dropdown").select("Oplopend");
        cy.get('.rental-vehicle-huurprijs__p')
        .then(p => {
          const values = p.toArray().map(element => parseFloat(element.innerText.replace('€', '').trim()));
      
          const isAscending = values.every((value, index, array) => {
            return index === 0 || array[index - 1] <= value;
          });
      
          expect(isAscending).to.be.true;
        });

        // Sort descending.
        cy.get(".divTop-reset-filters__button").click();
        cy.get(".divTop-divSelect-sorteren-dropdown").select("Aflopend");
        cy.get('.rental-vehicle-huurprijs__p')
        .then(p => {
          const values = p.toArray().map(element => parseFloat(element.innerText.replace('€', '').trim()));
      
          const isDescending = values.every((value, index, array) => {
            return index === 0 || array[index - 1] >= value;
          });
      
          expect(isDescending).to.be.true;
        });

        // Searchbox.
        cy.get(".divTop-reset-filters__button").click();
        cy.get(".divTop-search-bar__input").type("Golf");
        cy.get(".rental-vehicle-box__div").should("have.length", 1);

        // Reset the searchbox.
        cy.get(".divTop-reset-filters__button").click();
        cy.wait(100);
        cy.get(".rental-vehicle-box__div").should("have.length", 7);
    });
});
