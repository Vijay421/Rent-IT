/* eslint-disable */

describe("Back office employees can view rented vehicles", () => {
    it('should let back office employees view a page that contains all the vehicles that are currently being rented/unavailable with their hired period and the renter', () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("Login as particuliere huurder");
        cy.get("[data-cy='username']").type("p-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
        cy.wait(1600);

        cy.get("button").contains("Huren").click();
        cy.log("To /huur-overzicht page");

        cy.get("#date-picker-start").type("2025-02-01");
        cy.get("#date-picker-end").type("2025-02-04");

        cy.get("#rental-vehicle-huur-box__button").first().click();
        cy.log("to /huur-indienen page");

        cy.get("#form__wettelijke-naam").type("Test w naam");
        cy.get("#form__adres-gegevens").type("Test adres");
        cy.get("#form__stad-gegevens").type("Test stad");
        cy.get("#form__postcode-gegevens").type("1234AB");
        cy.get("#form__rijbewijs-nummer").type("1234567890");
        cy.get("#form__reisaard").type("test reisaard");
        cy.get("#form__verwachte-km").type("123");
        cy.get("#form__verste-punt").type("test v punt");
        cy.get("#form__start-punt").type("test start punt");
        cy.get("#form__eind-punt").type("test eind punt");

        cy.get(".submit-button__button").click();
        cy.log("to /bevestiging page");

        cy.intercept("POST", "https://localhost:53085/api/Huur").as("sendRentRequest");

        cy.get(".confirmation-button-box__button").click();
        cy.wait("@sendRentRequest").then((i) => {
            expect(i.response.statusCode).to.equal(201);
        });

        cy.get("button").contains("Profiel").click();
        cy.log("To /profiel page");

        cy.get("p").contains("Reserveringen").click();
        cy.log("To /reserveringen page");

        cy.get("[data-cy='annuleren']")
            .each((a) => {
                cy.wrap(a).click();
            });

        cy.get("button").contains("Huren").click();
        cy.log("To /huur-overzicht page");

        cy.get("#date-picker-start").type("2025-02-01");
        cy.get("#date-picker-end").type("2025-02-04");

        cy.get("#rental-vehicle-huur-box__button").first().click();
        cy.log("to /huur-indienen page");

        cy.get("#form__wettelijke-naam").type("Test w naam");
        cy.get("#form__adres-gegevens").type("Test adres");
        cy.get("#form__stad-gegevens").type("Test stad");
        cy.get("#form__postcode-gegevens").type("1234AB");
        cy.get("#form__rijbewijs-nummer").type("1234567890");
        cy.get("#form__reisaard").type("test reisaard");
        cy.get("#form__verwachte-km").type("123");
        cy.get("#form__verste-punt").type("test v punt");
        cy.get("#form__start-punt").type("test start punt");
        cy.get("#form__eind-punt").type("test eind punt");

        cy.get(".submit-button__button").click();
        cy.log("to /bevestiging page");

        cy.intercept("POST", "https://localhost:53085/api/Huur").as("sendRentRequest");

        cy.get(".confirmation-button-box__button").click();
        cy.wait("@sendRentRequest").then((i) => {
            expect(i.response.statusCode).to.equal(201);
        });

        cy.get("button").contains("Logout").click();
        cy.log("Logout of particuliere huurder");

        cy.visit("http://localhost:5173/login");

        cy.log("Login as back office medewerker");
        cy.get("[data-cy='username']").type("b-user");
        cy.get("[data-cy='password']").type("Qwerty123!");
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
        cy.wait(1600);

        cy.get("p").contains("Verhuurde voertuigen").click();
        cy.log("to /verhuurde-voertuigen page");

        cy.get(".verhuurde-voertuig-box__div").should("have.length", 1);
        //
        cy.get("#verhuurde-ophaaldatum__input").type("2025-02-01");
        cy.get("#verhuurde-inleverdatum__input").type("2025-02-04");

        cy.get("[data-cy='vehicle']").should("have.length", 1);

        cy.get("#verhuurde-reset-filters__button").click();

        cy.get("#verhuurde-ophaaldatum__input").type("2025-02-01");
        cy.get("#verhuurde-inleverdatum__input").type("2025-02-03");

        cy.get("[data-cy='vehicle']").should("have.length", 0);


        cy.get("#verhuurde-reset-filters__button").click();

        cy.get("#verhuurde-huurder__select").select("Test w naam");
        cy.get("[data-cy='vehicle']").should("have.length", 1);

        cy.get("#verhuurde-reset-filters__button").click();

        cy.get("#verhuurde-voertuigtype__select").select("Auto");
        cy.get("[data-cy='vehicle']").should("have.length", 0);

        cy.get("#verhuurde-voertuigtype__select").select("Camper");
        cy.get("[data-cy='vehicle']").should("have.length", 1);


        cy.get("#verhuurde-voertuigtype__select").select("Caravan");
        cy.get("[data-cy='vehicle']").should("have.length", 0);

        cy.get("#verhuurde-reset-filters__button").click();
        cy.get("[data-cy='vehicle']").should("have.length", 1);


        cy.get("#verhuurde-download_button").click();
    })
})