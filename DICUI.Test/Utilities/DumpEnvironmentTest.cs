﻿using System;
using System.Linq;
using DICUI.Data;
using DICUI.Utilities;
using Xunit;

namespace DICUI.Test
{
    public class DumpEnvironmentTest
    {
        [Theory]
        [InlineData(null, 'D', false, MediaType.NONE, false)]
        [InlineData("", 'D', false, MediaType.NONE, false)]
        [InlineData("cd F test.bin 8 /c2 20", 'F', false, MediaType.CDROM, true)]
        [InlineData("fd A test.img", 'A', true, MediaType.floppyDisk, true)]
        [InlineData("dvd X test.iso 8 /raw", 'X', false, MediaType.floppyDisk, false)]
        [InlineData("stop D", 'D', false, MediaType.DVD, true)]
        public void ParametersValidTest(string parameters, char letter, bool isFloppy, MediaType? mediaType, bool expected)
        {
            var env = new DumpEnvironment
            {
                DICParameters = new Parameters(parameters),
                Drive = isFloppy ? Drive.Floppy(letter) : Drive.Optical(letter, "", true),
                Type = mediaType,
            };

            bool actual = env.ParametersValid();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData(" ", "", " ", "")]
        [InlineData("super", "blah.bin", "super", "blah.bin")]
        [InlineData("super\\hero", "blah.bin", "super\\hero", "blah.bin")]
        [InlineData("super.hero", "blah.bin", "super_hero", "blah.bin")]
        [InlineData("superhero", "blah.rev.bin", "superhero", "blah_rev.bin")]
        [InlineData("super&hero", "blah.bin", "super_hero", "blah.bin")]
        [InlineData("superhero", "blah&foo.bin", "superhero", "blah_foo.bin")]
        public void FixOutputPathsTest(string outputDirectory, string outputFilename, string expectedOutputDirectory, string expectedOutputFilename)
        {
            var env = new DumpEnvironment
            {
                OutputDirectory = outputDirectory,
                OutputFilename = outputFilename,
            };

            env.FixOutputPaths();
            Assert.Equal(expectedOutputDirectory, env.OutputDirectory);
            Assert.Equal(expectedOutputFilename, env.OutputFilename);
        }

        [Fact]
        public void GetFirstTrackTest()
        {
            // TODO: Implement
            Assert.True(true);
        }

        [Theory]
        [InlineData(MediaType.CDROM)]
        [InlineData(MediaType.DVD)]
        [InlineData(MediaType.floppyDisk)]
        [InlineData(MediaType.LaserDisc)]
        public void FoundAllFilesTest(MediaType? mediaType)
        {
            // TODO: Implement
            // TODO: Get sample output data for each of the major types
            Assert.True(true);
        }

        [Theory]
        [InlineData(KnownSystem.AppleMacintosh, MediaType.CDROM)]
        [InlineData(KnownSystem.PhilipsCDi, MediaType.CDROM)]
        [InlineData(KnownSystem.SegaSaturn, MediaType.CDROM)]
        [InlineData(KnownSystem.SonyPlayStation, MediaType.CDROM)]
        [InlineData(KnownSystem.SonyPlayStation2, MediaType.CDROM)]
        [InlineData(KnownSystem.AppleMacintosh, MediaType.DVD)]
        [InlineData(KnownSystem.DVDVideo, MediaType.DVD)]
        [InlineData(KnownSystem.MicrosoftXBOX, MediaType.DVD)]
        [InlineData(KnownSystem.SonyPlayStation2, MediaType.DVD)]
        [InlineData(KnownSystem.BDVideo, MediaType.BluRay)]
        [InlineData(KnownSystem.AUSCOMSystem1, MediaType.Cassette)]
        public void ExtractOutputInformation(KnownSystem? knownSystem, MediaType? mediaType)
        {
            // TODO: Implement
            // TODO: Get sample output data for each of the major types
            Assert.True(true);
        }

        [Fact]
        public void FormatOutputDataTest()
        {
            // TODO: Implement
            Assert.True(true);
        }

        [Fact]
        public void WriteOutputDataTest()
        {
            // TODO: Implement
            Assert.True(true);
        }

        [Fact]
        public void EjectDiscTest()
        {
            // TODO: Implement
            Assert.True(true);
        }

        [Fact]
        public void CancelDumpingTest()
        {
            // TODO: Implement
            Assert.True(true);
        }

        [Fact]
        public void StartDumpingTest()
        {
            // TODO: Implement
            Assert.True(true);
        }
    }
}
