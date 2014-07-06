﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="James South">
//   Copyright (c) James South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Encapsulates a series of time saving extension methods to the <see cref="T:System.String" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageProcessor.Common.Extensions
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Encapsulates a series of time saving extension methods to the <see cref="T:System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Creates an array of integers scraped from the String.
        /// </summary>
        /// <param name="expression">The <see cref="T:System.String">String</see> instance that this method extends.</param>
        /// <returns>An array of integers scraped from the String.</returns>
        public static int[] ToPositiveIntegerArray(this string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentNullException("expression");
            }

            Regex regex = new Regex(@"[\d+]+(?=[,-])|[\d+]+(?![,-])", RegexOptions.Compiled);

            MatchCollection matchCollection = regex.Matches(expression);

            // Get the collections.
            int count = matchCollection.Count;
            int[] matches = new int[count];

            // Loop and parse the int values.
            for (int i = 0; i < count; i++)
            {
                matches[i] = int.Parse(matchCollection[i].Value, CultureInfo.InvariantCulture);
            }

            return matches;
        }

        /// <summary>
        /// Creates an array of floats scraped from the String.
        /// </summary>
        /// <param name="expression">The <see cref="T:System.String">String</see> instance that this method extends.</param>
        /// <returns>An array of floats scraped from the String.</returns>
        public static float[] ToPositiveFloatArray(this string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentNullException("expression");
            }

            Regex regex = new Regex(@"[\d+\.]+(?=[,-])|[\d+\.]+(?![,-])", RegexOptions.Compiled);

            MatchCollection matchCollection = regex.Matches(expression);

            // Get the collections.
            int count = matchCollection.Count;
            float[] matches = new float[count];

            // Loop and parse the int values.
            for (int i = 0; i < count; i++)
            {
                matches[i] = float.Parse(matchCollection[i].Value, CultureInfo.InvariantCulture);
            }

            return matches;
        }
    }
}
