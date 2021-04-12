/**
 * Conduct whether a string is null
 * @param str
 * @returns null => true or => false
 */
export function isNullString(str) {
    let bReturn = false;
    if (str === null || str === undefined || (typeof (str) === 'string' && str.replace(/(^s*)|(s*$)/g, "").length === 0)) {

        bReturn = true;

    }
    return bReturn;
}