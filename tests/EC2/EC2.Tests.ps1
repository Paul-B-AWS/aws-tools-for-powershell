. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "EC2" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Images" {

        It "Can get a filtered list of images" {
            $images = Get-EC2Image -Owner amazon -Filter @{Name="platform";Values="windows"},@{Name="architecture";Values="x86_64"}
            $images | Should Not Be $null
            $images.Count | Should BeGreaterThan 0
        }

        It "Can get a list of by-name image keys" {
            $imageKeys = Get-EC2ImageByName
            $imageKeys | Should Not Be $null
            $imageKeys.Count | Should BeGreaterThan 0
        }

        It "Can get an image by name" {
            $image = Get-EC2ImageByName windows_2012r2_base
            $image | Should Not Be $null
        }
    }
}

