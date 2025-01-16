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

// The following e2e test serves as an example.
describe("Particuliere user vehicles search and filter", () => {
  it("should go to huur-overzicht page and will search and filter vehicles", () => {
      cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
      cy.intercept("GET", "https://localhost:53085/api/Voertuig").as("getVehicles");

      cy.log("login as particuliere user");
      cy.visit("http://localhost:5173/login");

      cy.get("#login-gebruikersnaam").type("p-user");
      cy.get("#login-password").type("Qwerty123!");
      cy.get(".login-box__button").click();

      cy.wait('@loginRequest').then((interception) => {
          expect(interception.response.statusCode).to.equal(200);
      });


      cy.wait(1600);
      cy.log("go to '/huur-overzicht'");
      cy.get('a[href="/huur-overzicht"]').first().click();
      cy.wait("@getVehicles");


      cy.log("show all vehicles");
      cy.get("[data-cy='vehicle']").should("have.length.greaterThan", 0);


      cy.log("filter type");
      cy.get("[data-cy='kind-filter']").select("caravan");
      cy.get("[data-cy='kind']")
          .should('have.length.greaterThan', 0)
          .each(($p) => {
              expect($p).to.contain("Caravan");
          });


      cy.get("[data-cy='reset-button']").as("resetButton");
      cy.log("reset filters");
      cy.get("@resetButton").click();

      cy.log("filter dates");
      cy.get("#date-picker-start").type("2025-01-03");
      cy.get("#date-picker-end").type("2025-01-05");
      cy.get(".rental-vehicle-box__div").should("have.length", 1);


      cy.log("filter brand");
      cy.get("@resetButton").click();
      cy.get("[data-cy='brand-filter']").select("Toyota");
      cy.get("[data-cy='brand-type']")
          .should("have.length.greaterThan", 0)
          .each(($h3) => {
              expect($h3).to.contain("Toyota");
          });


      cy.log("filter price 0-50");
      cy.get("@resetButton").click();
      cy.get("[data-cy='price-filter']").select("0-50");
      cy.get("[data-cy='price']")
          .should("have.length.greaterThan", 0)
          .each(($p) => {
              const price = parseFloat($p.text().replace('€', '').replace('*', '').trim());

              const isSmallerOrEqual = price <= 50;

              expect(isSmallerOrEqual).to.be.true;
          });


      cy.log("filter availability (available)");
      cy.get("@resetButton").click();
      cy.get("[data-cy='availability-filter']").select("Beschikbaar");
      cy.get("[data-cy='status']")
          .should("have.length.greaterThan", 0)
          .each(($p) => {
              expect($p).to.contain("Verhuurbaar");
          });


      cy.log("filter availability (unavailable)");
      cy.get("[data-cy='availability-filter']").select("Onbeschikbaar");
      cy.get("[data-cy='status']")
          .should('have.length', 0)
          .each(($p) => {
              expect($p).to.contain("Onverhuurbaar");
          });
    cy.get("[data-cy='no-vehicles-text']")


      cy.log("sort ascending");
      cy.get("@resetButton").click();
      cy.get("[data-cy='sort-filter']").select("Oplopend");
      cy.get("[data-cy='price']")
          .should("have.length.greaterThan", 0)
          .then($p => {
          const values = $p.toArray().map(element => parseFloat(element.innerText.replace('€', '').trim()));
      
          const isAscending = values.every((value, index, array) => {
              return index === 0 || array[index - 1] <= value;
          });
      
          expect(isAscending).to.be.true;
          });


      cy.log("sort descending");
      cy.get("@resetButton").click();
      cy.get("[data-cy='sort-filter']").select("Aflopend");
      cy.get("[data-cy='price']")
          .should("have.length.greaterThan", 0)
          .then($p => {
          const values = $p.toArray().map(element => parseFloat(element.innerText.replace('€', '').trim()));
      
          const isDescending = values.every((value, index, array) => {
              return index === 0 || array[index - 1] >= value;
          });

          expect(isDescending).to.be.true;
          });


      cy.log("searchbox");
      cy.get("@resetButton").click();
      cy.get("[data-cy='search-bar']").type("Golf");
      cy.get("[data-cy='vehicle']").should("have.length.greaterThan", 0);

      cy.log("reset the searchbox");
      cy.get("@resetButton").click();
      cy.get("[data-cy='vehicle']").should("have.length.greaterThan", 1);
  });
});
