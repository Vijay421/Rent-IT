import React from "react";
import SubscriptionRequest from "../../src/components/SubscriptionRequest";

// An example test with a react component.
describe("<SubscriptionRequest />", () => {
    it("renders", () => {
    // see: https://on.cypress.io/mounting-react

    cy.mount(<SubscriptionRequest />);
    });
});
