/// <reference types="cypress" />

import getResponseClass from "../../../src/scripts/getResponseClass";

describe("get the correct css class name", () => {
    it("should return an empty class name when isError is null", () => {
        // Arrange
        const response = { isError: null };
        const className = "element";

        // Act
        const newClassName = getResponseClass(response, className);

        // Assert
        expect(newClassName).to.equal("");
    });

    it("should return an error class name when isError is true", () => {
        // Arrange
        const response = { isError: true };
        const className = "element";

        // Act
        const newClassName = getResponseClass(response, className);

        // Assert
        expect(newClassName).to.equal("element--error");
    });

    it("should return an success class name when isError is false", () => {
        // Arrange
        const response = { isError: false };
        const className = "element";

        // Act
        const newClassName = getResponseClass(response, className);

        // Assert
        expect(newClassName).to.equal("element--success");
    });
});
