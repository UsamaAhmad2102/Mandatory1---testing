// test for the api
// default test for the api to make sure it is sending the correct response
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});
pm.test("Content-Type is present", function () {
    pm.response.to.have.header("Content-Type");
});
pm.test("Response time is less than 200ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(200);
});
// GET Name test
pm.test("A name is returned", () => {
    pm.expect(pm.response.json()).to.have.property('firstname');
    pm.expect(pm.response.json().firstname).to.be.a('string');
})
// GET Address test
pm.test("A name is returned", () => {
    pm.expect(pm.response.json()).to.have.property('address');
    pm.expect(pm.response.json().address).to.be.a('string');
})
// GET cpr test
pm.test("A name is returned", () => {
    pm.expect(pm.response.json()).to.have.property('cpr');
    pm.expect(pm.response.json().cpr).to.be.a('string');
})
// GET full info test
pm.test("A name is returned", () => {
    pm.expect(pm.response.json()).to.have.property('firstname');
    pm.expect(pm.response.json().firstname).to.be.a('string');
    pm.expect(pm.response.json()).to.have.property('address');
    pm.expect(pm.response.json().address).to.be.a('string');
    pm.expect(pm.response.json()).to.have.property('cpr');
    pm.expect(pm.response.json().cpr).to.be.a('string');
})
// Get all users test
pm.test("A name is returned", () => {
    pm.expect(pm.response.json()).to.be.an('array');
})
