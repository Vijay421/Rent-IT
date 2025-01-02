/// <reference types="cypress" />

describe("back office employees can manage vehicles", () => {
    it("should let back office employees can create, retrieve, update and delete vehicles", () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as admin");
        cy.get("[data-cy='username']").type("b-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("POST", "https://localhost:53085/api/Voertuig").as("CreateVehicleRequest");
        cy.get("a[href='/voertuigoverzicht']").click();

        cy.log("create a vehicle");
        cy.get("[data-cy='create-vehicle']").click();
        cy.get("[data-cy='brand']").type("Merk");
        cy.get("[data-cy='type']").type("Type");
        cy.get("[data-cy='licensePlate']").type("AA-BB-CC");
        cy.get("[data-cy='color']").type("groen");
        cy.get("[data-cy='boughtYear']").type("2014");
        cy.get("[data-cy='kind']").select("Auto");
        cy.get("[data-cy='comment']").type("Een opmerking.");
        cy.get("[data-cy='status']").select("Verhuurbaar");
        cy.get("[data-cy='price']").type("42");
        cy.get("[data-cy='startDate']").type('2025-01-01');
        cy.get("[data-cy='EndDate']").type('2025-01-20');

        cy.get("[data-cy='submit']").click();

        cy.wait("@CreateVehicleRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(201);
        });


        cy.intercept("PUT", "https://localhost:53085/api/Voertuig/*").as("UpdateVehicleRequest");
        cy.log("update the vehicle");

        cy.get("a[href='/profiel']").click();
        cy.get("a[href='/voertuigoverzicht']").click();
        cy.get("[data-cy='update-vehicle']").last().click();

        cy.get("[data-cy='comment']").type("Een opmerking geüpdated.");

        cy.get("[data-cy='submit']").click();

        cy.wait("@UpdateVehicleRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });


        cy.intercept("DELETE", "https://localhost:53085/api/Voertuig/*").as("DeleteVehicleRequest");
        cy.log("delete the vehicle");

        cy.get("a[href='/profiel']").click();
        cy.get("a[href='/voertuigoverzicht']").click();

        cy.get("[data-cy='delete-vehicle']").last().click();

        cy.wait("@DeleteVehicleRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(204);
        });
    });
});
