/**
 * Gets the corresponding 'error' or 'success' css class name.
 * @param {Object} response
 * @param {string} response.msg
 * @param {bool} response.isError
 * @param {string} response.isError
 * @returns string
 */
export default function getResponseClass(response, className) {
    if (response.isError === null) {
        return '';
    } else {
        return className + '--' + (response.isError ? 'error' : 'success');
    }
}
