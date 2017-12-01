using System;
using Xunit;
using FluentAssertions;

namespace StringCalculator.Test
{
    public class StringCalculatorTest
    {
        private readonly StringCalc _sut;

        public StringCalculatorTest()
        {
            _sut = new StringCalc();
        }

        [Fact]
        public void should_return_zero_string_empty()
        {
            // ARRANGE & ACT
            int total = _sut.Add("");

            // ASSERT
            total.Should().Be(0);
        }

        [Fact]
        public void should_return_one_value_string_length_one()
        {
            //ARRANGE & ACT
            int total = _sut.Add("1");

            //ASSERT
            total.Should().Be(1);
        }

        [Fact]
        public void should_return_sum_string_length_two()
        {
            //ARRANGE & ACT
            int total = _sut.Add("1,2");

            //ASSERT
            total.Should().Be(3);
        }

        [Fact]
        public void should_return_sum_string_length_variability()
        {
            //ARRANGE & ACT
            int total = _sut.Add("1,2,3,3");

            //ASSERT
            total.Should().Be(9);
        }

        [Fact]
        public void should_return_sum_string_with_another_separator()
        {
            //ARRANGE & ACT
            int total = _sut.Add("1\n2,3");

            //ASSERT
            total.Should().Be(6);
        }

        [Fact]
        public void should_return_sum_string_final_characther_is_separator()
        {
            //ARRANGE & ACT
            int total = _sut.Add("1,\n");

            //ASSERT
            total.Should().Be(1);
        }

        [Fact]
        public void should_return_sum_string_with_separator_customizable()
        {
            //ARRANGE & ACT
            int total = _sut.Add("//;\n1;2");

            //ASSERT
            total.Should().Be(3);
        }

        [Fact]
        public void should_exception_string_with_negative_value()
        {
            //ARRANGE & ACT & ASSERT
            Action act = () => _sut.Add("-1,2");
            act.ShouldThrow<ArgumentException>().WithMessage("Negatives not allowed -1");
        }

        [Fact]
        public void should_return_sum_string_have_number_less_1k()
        {
            //ARRANGE & ACT
            int total = _sut.Add("2,1001");

            //ASSERT
            total.Should().Be(2);
        }

        [Fact]
        public void should_return_sum_string_have_separator_with_different_length()
        {
            //ARRANGE & ACT
            int total = _sut.Add("//[***]\n1***2***3");

            //ASSERT
            total.Should().Be(6);
        }

        [Fact]
        public void should_return_sum_string_have_more_separator()
        {
            //ARRANGE & ACT
            int total = _sut.Add("//[*][%]\n1*2%3");

            //ASSERT
            total.Should().Be(6);
        }

        [Fact]
        public void should_return_sum_string_have_more_separator_with_difference_length()
        {
            //ARRANGE & ACT
            int total = _sut.Add("//[***][%]\n1***2%3");

            //ASSERT
            total.Should().Be(6);
        }
    }
}