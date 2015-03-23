# -*- mode: ruby -*-
# vi: set ft=ruby :

# Use this vagrant file to provision a local developer box
# This box will contain some basic development tools and the necessary runtime
# to run the web application on your local machine.
#
# You can develop in this machine, but I would recommend that you work from your
# host and run the application in this box.


Vagrant.configure(2) do |config|
  config.vm.box = "ubuntu/trusty64"

  # In order to get the best performance we need to boost the box a little bit.
  # If you have more CPUs available, add them!
  config.vm.provider "virtualbox" do |v|
    v.memory = 4096
    v.cpus = 2
  end

  # Expose port 3000 for the StoreCatalog service
  config.vm.network "forwarded_port", guest: 3000, host: 3000

  # This first script installs the basics needed to get the box in shape
  # for running ASP.NET 5 + the latest version of mono. This script also
  # includes a few basic things that you need to edit the source files.
  config.vm.provision "shell", inline: <<-SHELL
    # Install a few basic tools for the vm
    sudo apt-get update
    sudo apt-get -y install curl unzip vim git autoconf libtool automake build-essential gettext

    # Add the extra source for the latest version of Mono
    sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
    echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
    sudo apt-get update

    # Install the latest greatest mono version
    sudo apt-get -y install mono-devel
    mozroots --import --sync
  SHELL

  # This second script installs the new runtime manager on the box.
  # The installation happens as the vagrant user, so that we can use it when we log in as that user.
  config.vm.provision "shell", privileged: false, inline: <<-SHELL
    # Prepare the installation folder for the latest mono version
    sudo mkdir -p /usr/local
    sudo chown -R `whoami` /usr/local

    # Clone the sources and build them
    git clone https://github.com/mono/mono.git ~/mono
    cd ~/mono
    ./autogen.sh --prefix=/usr/local
    make
    sudo make install
    cd ~/

    # Clone the sources for libuv (Needed by Kestrel) and build them
    git clone https://github.com/libuv/libuv.git ~/libuv
    cd ~/libuv
    sh autogen.sh
    ./configure
    make
    sudo make install
    sudo ldconfig

    # Set the PATH so that the locally compiled mono binaries are
    # detected before the ones we installed before.
    export PATH=/usr/local/bin:$PATH

    # Load the dnvm stuff and get the latest runtime for the application
    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh; dnvm upgrade
  SHELL
end
