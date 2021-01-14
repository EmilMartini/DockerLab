it('open page', () => {
    cy.visit("http://localhost:1234")
})

it('create bug report', () => {
    cy.get('#box').type('This is a test log and it is going to be deleted 2545151984654651681635161355165132165416546513521651651');
    cy.get('#reportbutton').click()

})
it('press viewpage button', () => {
    cy.get('#viewpage').click()
    cy.get('#0').click()
})

it('press completepage button', () => {
    cy.get('#completepage').click()
    cy.get('#0').click()
})

it('Delete test row', () => {
    cy.request('DELETE', "http://localhost:1336/api/Report/Bug")
})
