it('open page', () => {
    cy.visit('http://localhost:1234/Report')
})


it('create bug report', () => {
    cy.get('#box').type('Test nummer 2')
})
//
it('press report button', () => {
    cy.get('#reportbutton').click()
})
//

it('press viewpage button', () => {
    cy.get('#viewpage').click()
})

it('press completepage button', () => {
    cy.get('#completepage').click()
})
it('press reportpage button', () => {
    cy.get('#reportpage').click()
})