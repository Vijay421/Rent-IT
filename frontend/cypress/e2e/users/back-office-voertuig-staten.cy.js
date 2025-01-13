/* eslint-ignore */

const USERNAME = 'b-user';
const PASSWORD = 'Qwerty123!';

describe("Back office employees can see vehicle states");
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

    cy.intercept("GET","https://localhost:53085/api/Voertuig").as("getVehicles");

    cy.get("[data-cy='voertuig-staten-button']").click();
    cy.log("to /voertuig-staten page");
    cy.wait("@getVehicles");

    cy.log('Check overall amount of vehicles');
    cy.get("[data-cy='staten-voertuig-box']").children().should("have.length", 7);

    cy.log('Check check if vehicle 1 status is Verhuurbaar');
    cy.get("[data-cy='staten-voertuig-box']").children().eq(0).find("[data-cy='voertuig-status-select']").should("have.value", "Verhuurbaar");

    cy.log('Check check if vehicle 7 status is Verhuurbaar');
    cy.get("[data-cy='staten-voertuig-box']").children().eq(6).find("[data-cy='voertuig-status-select']").should("have.value", "Verhuurbaar");

    cy.log("Set vehicle 1 status to Onverhuurbaar");
    cy.get("[data-cy='staten-voertuig-box']").children().eq(1).find("[data-cy='voertuig-status-select']").select("Onverhuurbaar");

    cy.log('Check check if vehicle 2 status is Onverhuurbaar');
    cy.get("[data-cy='staten-voertuig-box']").children().eq(1).find("[data-cy='voertuig-status-select']").should("have.value","Onverhuurbaar");

    cy.log('Set staat filter to Beschikbaar and check if amount of vehicles is 6');
    cy.get("[data-cy='staat-filter-select']").select("Beschikbaar");
    cy.get("[data-cy='staten-voertuig-box']").children().should("have.length", 6);

    cy.log('Set staat filter to Verhuurd and check if amount of vehicles is 1');
    cy.get("[data-cy='staat-filter-select']").select("Verhuurd");
    cy.get("[data-cy='staten-voertuig-box']").children().should("have.length", 1);

    cy.log('Reset all filters');
    cy.get("[data-cy='staten-reset-filter-button']").click();

    cy.log('Set vehicle 4, 5 statuses to Reparatie and vehicle 6 status to geblokkeerd');
    cy.get("[data-cy='staten-voertuig-box']").children().eq(3).find("[data-cy='voertuig-status-select']").select("Reparatie");
    cy.get("[data-cy='staten-voertuig-box']").children().eq(4).find("[data-cy='voertuig-status-select']").select("Reparatie");
    cy.get("[data-cy='staten-voertuig-box']").children().eq(5).find("[data-cy='voertuig-status-select']").select("Geblokkeerd");

    cy.log("Set staat filter to In reparatie and check if amount of vehicles is 2");
    cy.get("[data-cy='staat-filter-select']").select("In reparatie");
    cy.get("[data-cy='staten-voertuig-box']").children().should("have.length", 2);

    cy.log("Set staat filter to Geblokkeerd and check if amount of vehicles is 1");
    cy.get("[data-cy='staat-filter-select']").select("Geblokkeerd");
    cy.get("[data-cy='staten-voertuig-box']").children().should("have.length", 1);

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
    cy.get("[data-cy='start-datum-input']").type("2025-01-01");
    cy.get("[data-cy='eind-datum-input']").type("2025-01-04");
    cy.get("[data-cy='staten-voertuig-box']").children().should("have.length",2);

    cy.log("Set data end date filter to February 3 and check if amount of vehicles is 0");
    cy.get("[data-cy='eind-datum-input']").type("2025-01-03");
    cy.get("[data-cy='staten-voertuig-box']").children().should("have.length",0);

    cy.log('Reset all filters');
    cy.get("[data-cy='staten-reset-filter-button']").click();

    cy.log("Complete");
});
