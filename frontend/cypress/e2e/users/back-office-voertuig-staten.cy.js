
const USERNAME = 'b-user';
const PASSWORD = 'Qwerty123!';

describe("Back office employees can see vehicle states", () => {
    it('should let the back office employees see a list of all the vehicles and their statuses', () => {
        cy.intercept("POST", "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true").as("loginRequest");
        cy.visit("http://localhost:5173/login");

        cy.log("login as back office employee");
        cy.get("[data-cy='username']").type(USERNAME);
        cy.get("[data-cy='password']").type(PASSWORD);
        cy.get("[data-cy='submit']").click();

        cy.wait("@loginRequest").then((interception) => {
            expect(interception.response.statusCode).to.equal(200);
        });
        cy.wait(1600);

        cy.intercept("GET", "https://localhost:53085/api/Voertuig").as("getVehicles");

        cy.get("a[href='/voertuig-staten']").click();
        cy.log("to /voertuig-staten page");
        cy.wait("@getVehicles");


        cy.intercept("PUT", "https://localhost:53085/api/Voertuig/*").as("updateStatusRequest");

        cy.log("Set all vehicle statuses back to Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(0).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(1).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(2).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(3).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(4).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(5).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(6).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");

        cy.log('Check check if vehicle 1 status is Verhuurbaar');
        cy.get("[data-cy='staten-voertuig-box']").children().eq(0).find("[data-cy='voertuig-status-select']").should("have.value", "Verhuurbaar");

        cy.log('Check check if vehicle 7 status is Verhuurbaar');
        cy.get("[data-cy='staten-voertuig-box']").children().eq(6).find("[data-cy='voertuig-status-select']").should("have.value", "Verhuurbaar");

        cy.log("Set vehicle 1 status to Onverhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(1).find("[data-cy='voertuig-status-select']").select("Onverhuurbaar");

        cy.log('Check check if vehicle 2 status is Onverhuurbaar');
        cy.get("[data-cy='staten-voertuig-box']").children().eq(1).find("[data-cy='voertuig-status-select']").should("have.value", "Onverhuurbaar");

        cy.log('Set staat filter to Beschikbaar');
        cy.get("[data-cy='staat-filter-select']").select("Beschikbaar");
        cy.wait(5000);
        cy.get("[data-cy='voertuig-status-select']")
            .each(element => {
                cy.wrap(element)
                .invoke('val')
                .then(value => expect(value).to.equal("Verhuurbaar"));
            });

        cy.log('Set staat filter to Verhuurd');
        cy.get("[data-cy='staat-filter-select']").select("Verhuurd");
        cy.wait("@updateStatusRequest");
        cy.get("[data-cy='voertuig-status-select']")
            .each(element => {
                cy.wrap(element)
                .invoke('val')
                .then(value => expect(value).to.equal("Onverhuurbaar"));
            });

        cy.log('Reset all filters');
        cy.get("[data-cy='staten-reset-filter-button']").click();

        cy.log('Set vehicle 4, 5 statuses to Reparatie and vehicle 6 status to geblokkeerd');
        cy.get("[data-cy='staten-voertuig-box']").children().eq(3).find("[data-cy='voertuig-status-select']").select("Reparatie");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(4).find("[data-cy='voertuig-status-select']").select("Reparatie");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(5).find("[data-cy='voertuig-status-select']").select("Geblokkeerd");
        cy.wait("@updateStatusRequest");

        cy.log("Set staat filter to In reparatie and check if amount of vehicles is 2");
        cy.get("[data-cy='staat-filter-select']").select("In reparatie");
        cy.wait("@updateStatusRequest");
        cy.get("[data-cy='voertuig-status-select']")
            .each(element => {
                cy.wrap(element)
                .invoke('val')
                .then(value => expect(value).to.equal("Reparatie"));
            });

        cy.log("Set staat filter to Geblokkeerd and check if amount of vehicles is 1");
        cy.get("[data-cy='staat-filter-select']").select("Geblokkeerd");
        cy.wait("@updateStatusRequest");
        cy.get("[data-cy='voertuig-status-select']")
            .each(element => {
                cy.wrap(element)
                .invoke('val')
                .then(value => expect(value).to.equal("Geblokkeerd"));
            });

        cy.log('Reset all filters');
        cy.get("[data-cy='staten-reset-filter-button']").click();

        cy.log("Set all vehicle statuses back to Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(0).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(1).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(2).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(3).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(4).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(5).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");
        cy.get("[data-cy='staten-voertuig-box']").children().eq(6).find("[data-cy='voertuig-status-select']").select("Verhuurbaar");


        cy.log("Set data filters to February 1 and February 4 and check if amount of vehicles is 2");
        cy.get("[data-cy='staten-start-datum-input']").type("2025-01-01");
        cy.get("[data-cy='staten-eind-datum-input']").type("2025-01-04");
        cy.wait("@updateStatusRequest");
        cy.get('[data-cy="vehicle"]').each((element) => {
            cy.wrap(element)
              .invoke('attr', 'data-start-date')
              .then(startDate => expect(new Date(startDate)).to.lte(new Date("2025-01-01")));
          });

        cy.get('[data-cy="vehicle"]').each((element) => {
            cy.wrap(element)
              .invoke('attr', 'data-end-date')
              .then(endDate => expect(new Date(endDate)).to.gte(new Date("2025-01-04")));
          });

        cy.log("Set data end date filter to February 3 and check if amount of vehicles is 0");
        cy.get("[data-cy='staten-eind-datum-input']").type("2025-01-03");
        cy.get("[data-cy='staten-voertuig-box']").children().should("contain", "Geen voertuigen gevonden.");

        cy.log('Reset all filters');
        cy.get("[data-cy='staten-reset-filter-button']").click();

        cy.log("Complete");
    });
});