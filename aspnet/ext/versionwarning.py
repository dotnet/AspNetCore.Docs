# -*- coding: utf-8 -*-
"""
Add the ability to specify the version for a specific page.

This allows you to put metadata at the top of your document::

    :version: 2.3

This version should be the version of the project that this page or API targets.

If you configure ``versionwarning_node`` to True (default),
then it will generate an in-page warning for out of date versions.

If you configure ``versionwarning_console`` to True (default),
then it will output a warning on the console.
"""


from collections import defaultdict

from sphinx.util.console import red, bold
from docutils import nodes


def process_meta(app, doctree, fromdocname):
    env = app.builder.env
    env.page_to_version = defaultdict(set)
    env.version_to_page = defaultdict(set)

    # index metadata
    for pagename, metadata in iter(env.metadata.items()):
        if 'version' in metadata:
            version = metadata['version']
            env.page_to_version[pagename] = version
            env.version_to_page[version].add(pagename)

            if fromdocname == pagename:

                # Alert on outdated version
                current_version = env.config['version']
                if version != current_version:
                    text = 'This page documents version {old} and has not yet been updated for version {new}'.format(
                        old=version,
                        new=current_version,
                    )

                    if app.config['versionwarning_node']:
                        prose = nodes.paragraph(text, text)
                        warning = nodes.warning(prose, prose)
                        doctree.insert(0, warning)
                    if app.config['versionwarning_console']:
                        app.warn(bold('[Version Warning: %s] ' % pagename) + red(text))


def setup(app):
    app.connect('doctree-resolved', process_meta)
    app.add_config_value('versionwarning_node', True, 'html')
    app.add_config_value('versionwarning_console', True, 'html')
