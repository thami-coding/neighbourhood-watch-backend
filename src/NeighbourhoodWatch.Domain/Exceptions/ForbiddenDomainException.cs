namespace NeighbourhoodWatch.Domain.Exceptions;

public class ForbiddenDomainException(string message) : DomainException(message);