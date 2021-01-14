it('open page', () => {
    cy.visit("http://localhost:1234")
})

it('create bug report', () => {
    cy.get('#box').type('Test');
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
