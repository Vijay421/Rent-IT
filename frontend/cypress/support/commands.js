// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })

Cypress.Commands.add("login", (username, password) => {
    cy.request({
        method: "POST",
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        url: "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true",
        body: {
            email: username,
            password: password,
        },
    }).then((response) => {
        expect(response.status).to.equal(200);
    });
});

Cypress.Commands.add('deleteUser', (username, password) => {
    cy.log("cleaning up test user if it exists");

    cy.request({
        method: "POST",
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        url: "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true",
        body: {
            email: username,
            password: password,
        },
        failOnStatusCode: false, // Don't fail even if user does not exist.
    }).then((response) => {
        if (response.status === 200) {
            cy.request({
                method: "DELETE",
                credentials: 'include', // TODO: change to 'same-origin' when in production.
                url: "https://localhost:53085/api/User",
            }).then((deleteResponse) => {
                cy.log("test user deleted, status:", deleteResponse.status);
            });
        } else {
            cy.log("user does not exist, no cleanup needed");
        }
    });
});

Cypress.Commands.add("loginFail", (username, password) => {
    cy.request({
        method: "POST",
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        url: "https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true",
        body: {
            email: username,
            password: password,
        },
        failOnStatusCode: false, // Don't fail even if user does not exist.
    }).then((response) => {
        expect(response.status).to.equal(401);
    });
});
