using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ControleEmpresarial.Core.Domain.Events;

namespace ControleEmpresarial.Core.Domain.ValuesObjects
{
    public static class AssertionConcern
    {
        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return !notificationsNotNull.Any();
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(DomainEvent.Raise);
        }

        public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            if (string.IsNullOrEmpty(stringValue))
                return new DomainNotification("AssertArgumentLength", message);

            var length = stringValue.Trim().Length;

            return (length < minimum || length > maximum) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertFixedLength(string stringValue, int size, string message)
        {
            if (string.IsNullOrEmpty(stringValue))
                return new DomainNotification("AssertArgumentLength", message);

            var length = stringValue.Trim().Length;

            return (length != size) ?
                new DomainNotification("AssertArgumentFixedLength", message) : null;
        }

        public static DomainNotification AssertMatches(string pattern, string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrEmpty(pattern))
                return new DomainNotification("AssertArgumentLength", message);

            var regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue)) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertNotNullOrEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue)) ?
                new DomainNotification("AssertArgumentNotEmpty", message) : null;
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {

            return (object1 == null) ?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }

        public static DomainNotification AssertIsNull(object object1, string message)
        {

            return (object1 != null) ?
                new DomainNotification("AssertArgumentIsNull", message) : null;
        }

        public static DomainNotification AssertTrue(bool boolValue, string message)
        {
            return (!boolValue) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertAreEquals(string value, string match, string message)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(match))
                return new DomainNotification("AssertArgumentLength", message);

            return (value != match) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertGreaterThanZero(decimal value, string message)
        {
            return (value < 0) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertGuidIsValid(Guid value, string message)
        {
            return (value == Guid.Empty) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }
    }
}